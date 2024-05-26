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
    RoundState roundState,
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

        var state = boardState.MovePlayer(player, notification.Steps);
        if (state.HasFlag(PlayerMovedState.MovedThroughGo))
        {
            await hub.NotifyAllPlayers("PlayerMovedThroughGo", new { player.Id, player.Money }, cancellationToken);
        }

        var playerPosition = player.Position;
        await hub.NotifyAllPlayers("PlayerMoved", new { player.Id, playerPosition }, cancellationToken);

        var field = boardState.GetField(playerPosition);
        if (field is null)
        {
            logger.LogWarning("Field with position {Position} not found", playerPosition);
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
                await hub.NotifyAllPlayers("PlayerGoToJail", new { player.Id }, cancellationToken);
                break;
            case SpecialFields.JailVisit:
                break;
            case SpecialFields.CommunityChest:
                break;
            case SpecialFields.Chance:
                break;
            case SpecialFields.IncomeTax:
                // TODO: Handle bankrupt
                const int incomeTax = 200;

                player.Money -= incomeTax;

                logger.LogInformation("Player {Id} - {Nickname} pay income tax", player.Id, player.Nickname);
                await hub.NotifyPlayer(player.Id, "PayIncomeTax", new { incomeTax }, cancellationToken);
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
                await hub.NotifyPlayer(player.Id, "CanBuyField", new { fieldProperty.Name, fieldProperty.Price }, cancellationToken);
                break;
            default:
                await PayRent(player, fieldProperty, cancellationToken);
                break;
        }
    }

    private async Task PayRent(Player player, Property property, CancellationToken cancellationToken = default)
    {
        var owner = playersState.GetPlayerById(property.OwnerId ?? string.Empty);
        if (owner is null)
        {
            logger.LogWarning("Owner with id {OwnerId} not found", property.OwnerId);
            return;
        }

        var rent = property.CalculateRentToPay();
        if (player.Money < rent)
        {
            await HandleBankrupt(player, owner, cancellationToken);
            return;
        }

        player.Money -= rent;
        owner.Money += rent;

        logger.LogInformation("Player {Id} - {Nickname} pay rent {Rent} to {OwnerId} - {OwnerNickname}", player.Id,
            player.Nickname, rent, owner.Id, owner.Nickname);

        await hub.NotifyPlayer(player.Id, "PayRent", new { owner.Nickname, rent }, cancellationToken);
        await hub.NotifyPlayer(owner.Id, "ReceiveRent", new { player.Nickname, rent }, cancellationToken);
    }

    private async Task HandleBankrupt(Player player, Player owner, CancellationToken cancellationToken = default)
    {
        var rent = player.Money;

        owner.Money += rent;
        roundState.BankruptPlayer(player);
        boardState.RemovePlayerCards(player.Id);

        logger.LogInformation("Player {Id} - {Nickname} is bankrupt", player.Id, player.Nickname);
        var currentPlayerId = gameState.GetCurrentPlayerId();

        await hub.NotifyPlayer(currentPlayerId, "YourTurn", cancellationToken);
        await hub.NotifyAllPlayers("NextPlayer", new { currentPlayerId }, cancellationToken);

        await hub.NotifyPlayer(owner.Id, "ReceiveRent", new { player.Nickname, rent }, cancellationToken);
        await hub.NotifyAllPlayers("PlayerBankrupt", new { player.Id }, cancellationToken);
    }
}