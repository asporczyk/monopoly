using MediatR;
using Microsoft.Extensions.Logging;
using Monopoly.GameManagement.Abstract;
using Monopoly.GameManagement.Notifications;
using Monopoly.GameManagement.States;

namespace Monopoly.GameManagement.Handlers;

public class BuyHotelNotificationHandler(
    GameState gameState,
    BoardState boardState,
    IGameHubService hub,
    ILogger<BuyHotelNotificationHandler> logger
) : INotificationHandler<BuyHotelNotification>
{
    public async Task Handle(BuyHotelNotification notification, CancellationToken cancellationToken)
    {
        var player = gameState.GetCurrentPlayer();
        if (player.Id != notification.ConnectionId)
        {
            logger.LogWarning("Player {Id} - {Nickname} is not the current player", player.Id, player.Nickname);
            return;
        }

        var field = boardState.GetField(player.Position);
        if (field is null)
        {
            logger.LogWarning("Field with position {Position} not found", player.Position);
            return;
        }

        if (field.Property is null)
        {
            logger.LogWarning("Field with position {Position} is not a property", player.Position);
            return;
        }

        if (field.Property.OwnerId is null || field.Property.OwnerId != player.Id)
        {
            logger.LogWarning("Can't buy field by player {Id} - {Nickname}", player.Id, player.Nickname);
            return;
        }

        if (field.Property.HasHotel)
        {
            logger.LogWarning("Field with position {Position} already has hotel", player.Position);
            return;
        }

        if (field.Property.Houses != 4)
        {
            logger.LogWarning("Field with position {Position} has not 4 houses", player.Position);
            return;
        }

        if (player.Money < field.Property.HotelCost)
        {
            logger.LogWarning("Player {Id} - {Nickname} has not enough money to buy a house", player.Id, player.Nickname);
            return;
        }

        player.Money -= field.Property.HotelCost;
        field.Property.HasHotel = true;
        field.Property.Houses = 0;

        await hub.NotifyAllPlayers("HotelBought", new { player.Id, field.Property.Name, field.Property.HasHotel, field.Property.HotelCost }, cancellationToken);
    }
}