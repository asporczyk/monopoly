using MediatR;
using Microsoft.Extensions.Logging;
using Monopoly.GameCore.Dictionary;
using Monopoly.GameCore.Models;
using Monopoly.GameLogic.Services;
using Monopoly.GameManagement.Abstract;
using Monopoly.GameManagement.Notifications;
using Monopoly.GameManagement.States;

namespace Monopoly.GameManagement.Handlers;

public class MovePlayerNotificationHandler(
    GameState gameState,
    PlayersState playersState,
    BoardState boardState,
    IGameHubService hub,
    ILogger<MovePlayerNotificationHandler> logger
) : INotificationHandler<MovePlayerNotification>
{
    public async Task Handle(MovePlayerNotification notification, CancellationToken cancellationToken)
    {
        var player = gameState.GetCurrentPlayer();
        if (player.Id != notification.ConnectionId)
        {
            logger.LogWarning("Player {Id} - {Nickname} is not the current player", player.Id, player.Nickname);
            return;
        }

        boardState.MovePlayer(player, notification.Steps);
        await hub.NotifyAllPlayers("PlayerMoved", new { player.Id, notification.Steps }, cancellationToken);

        var field = boardState.GetField(player.Position);
        if (field is null)
        {
            logger.LogWarning("Field with position {Position} not found", player.Position);
            return;
        }

        switch (field)
        {
            case { Property: not null }:
                await HandlePropertyField(player, field.Property, cancellationToken);
                break;
            case { SpecialField: not null }:
                await HandleSpecialField(player, (SpecialFields)field.SpecialField, cancellationToken);
                break;
        }
    }

    private async Task HandleSpecialField(Player player, SpecialFields fieldSpecialField, CancellationToken cancellationToken = default)
    {
        switch (fieldSpecialField)
        {
            case SpecialFields.Go:
                break;
            case SpecialFields.GoToJail:
                JailService.GoToJail(player);

                logger.LogInformation("Player {Id} - {Nickname} go to jail", player.Id, player.Nickname);
                await hub.NotifyAllPlayers("PlayerGoToJail", player.Id, cancellationToken);
                break;
            case SpecialFields.JailVisit:
                break;
            case SpecialFields.CommunityChest:
                break;
            case SpecialFields.Chance:
                break;
            case SpecialFields.IncomeTax:
                const int incomeTax = 200;

                player.Money -= incomeTax;

                logger.LogInformation("Player {Id} - {Nickname} pay income tax", player.Id, player.Nickname);
                await hub.NotifyPlayer(player.Id, "PayIncomeTax", incomeTax, cancellationToken);
                break;
            case SpecialFields.FreeParking:
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(fieldSpecialField), fieldSpecialField, "Special field not implemented");
        }
    }

    private async Task HandlePropertyField(Player player, Property fieldProperty, CancellationToken cancellationToken = default)
    {
        switch (fieldProperty)
        {
            case { OwnerId: null }:
                await hub.NotifyPlayer(player.Id, "CanBuyField", new { fieldProperty.Name }, cancellationToken);
                break;
            default:
                await PayRent(player, fieldProperty);
                break;
        }
    }

    private async Task PayRent(Player player, Property property)
    {
        var owner = playersState.GetPlayerById(property.OwnerId ?? string.Empty);
        if (owner is null)
        {
            logger.LogWarning("Owner with id {OwnerId} not found", property.OwnerId);
            return;
        }

        var rent = property.GetRentToPay();

        player.Money -= rent;
        owner.Money += rent;

        logger.LogInformation("Player {Id} - {Nickname} pay rent {Rent} to {OwnerId} - {OwnerNickname}", player.Id,
            player.Nickname, rent, owner.Id, owner.Nickname);
        await hub.NotifyPlayer(player.Id, "PayRent", new { owner.Nickname, rent });
        await hub.NotifyPlayer(owner.Id, "ReceiveRent", new { player.Nickname, rent });
    }
}