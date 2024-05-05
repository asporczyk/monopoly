using MediatR;
using Microsoft.Extensions.Logging;
using Monopoly.GameCore.Models;
using Monopoly.GameManagement.Abstract;
using Monopoly.GameManagement.Notifications;
using Monopoly.GameManagement.States;
using Serilog;

namespace Monopoly.GameManagement.Handlers;

internal class BuyFieldNotificationHandler(
    PlayersState playersState,
    BoardState boardState,
    IGameHubService hub,
    ILogger<BuyFieldNotificationHandler> logger
) : INotificationHandler<BuyFieldNotification>
{
    public async Task Handle(BuyFieldNotification notification, CancellationToken cancellationToken)
    {
        var player = playersState.GetPlayerById(notification.ConnectionId);
        if (player is null)
        {
            logger.LogWarning("Player with connection id {ConnectionId} not found", notification.ConnectionId);
            return;
        }

        var property = boardState.Fields[player.Position].Property;
        if (property is null)
        {
            logger.LogWarning("Player {Nickname} landed on a field without property", player.Nickname);
            return;
        }


        if (!BuyProperty(property, player))
        {
            return;
        }

        logger.LogInformation("Player {Id} - {Nickname} bought: {Name}", player.Id, player.Nickname, property.Name);
        await hub.NotifyAllPlayers("FieldBought", new { player.Id, property.Name }, cancellationToken);
    }

    private static bool BuyProperty(Property property, Player player)
    {
        if (property.OwnerId is not null)
        {
            Log.Information("Property {Name} is already owned by {OwnerId}", property.Name, property.OwnerId);
            return false;
        }

        if (player.Money < property.Price)
        {
            Log.Information("Player {PlayerId} does not have enough money to buy {Name}", player.Id, property.Name);
            return false;
        }

        player.Money -= property.Price;
        property.OwnerId = player.Id;
        return true;
    }
}