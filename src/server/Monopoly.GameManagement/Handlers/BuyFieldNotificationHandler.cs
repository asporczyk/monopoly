using MediatR;
using Microsoft.Extensions.Logging;
using Monopoly.GameCore.Models;
using Monopoly.GameManagement.Abstract;
using Monopoly.GameManagement.Notifications;
using Monopoly.GameManagement.States;
using Serilog;

namespace Monopoly.GameManagement.Handlers;

internal class BuyFieldNotificationHandler(
    BoardState boardState,
    GameState gameState,
    IGameHubService hub,
    ILogger<BuyFieldNotificationHandler> logger
) : INotificationHandler<BuyFieldNotification>
{
    public async Task Handle(BuyFieldNotification notification, CancellationToken cancellationToken)
    {
        var player = gameState.GetCurrentPlayer();
        if (player.Id != notification.ConnectionId)
        {
            logger.LogWarning("Player {Id} - {Nickname} is not the current player", player.Id, player.Nickname);
            return;
        }

        var property = boardState.Fields[player.Position].Property;
        if (property is null)
        {
            logger.LogWarning("Player {Id} - {Nickname} landed on a field without property",
                player.Id,
                player.Nickname
            );
            return;
        }


        var isPropertyBought = BuyProperty(property, player);
        if (!isPropertyBought)
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