using MediatR;
using Microsoft.Extensions.Logging;
using Monopoly.GameCore.Models;
using Monopoly.GameLogic.Services;
using Monopoly.GameManagement.Abstract;
using Monopoly.GameManagement.Notifications;
using Monopoly.GameManagement.States;

namespace Monopoly.GameManagement.Handlers;

public class MovePlayerNotificationHandler(
    PlayersState playersState,
    BoardState boardState,
    IGameHubService hub,
    ILogger<MovePlayerNotificationHandler> logger
) : INotificationHandler<MovePlayerNotification>
{
    public async Task Handle(MovePlayerNotification notification, CancellationToken cancellationToken)
    {
        var player = playersState.GetPlayerById(notification.ConnectionId);
        if (player is null)
        {
            logger.LogWarning("Player with connection id {ConnectionId} not found", notification.ConnectionId);
            return;
        }

        boardState.MovePlayer(player, notification.Steps);
        await hub.NotifyAllPlayers("PlayerMoved", new { player.Id, notification.Steps }, cancellationToken);

        if (player.Position is BoardState.JailPosition)
        {
            JailService.GoToJail(player);

            logger.LogInformation("Player {Id} - {Nickname} go to jail", player.Id, player.Nickname);
            await hub.NotifyAllPlayers("PlayerGoToJail", player.Id, cancellationToken);
            return;
        }

        var property = boardState.Fields[player.Position].Property;
        switch (property)
        {
            case null:
                // TODO: Implement SPECIAL FIELDS
                await hub.NotifyPlayer(player.Id, "SpecialFields", "Chance/Community Chest", cancellationToken);
                break;
            case { OwnerId: null }:
                await hub.NotifyPlayer(player.Id, "CanBuyField", new { property.Name }, cancellationToken);
                break;
            case { OwnerId: { } ownerId } when ownerId != player.Id:
                await PayRent(player, property);
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