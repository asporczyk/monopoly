using MediatR;
using Microsoft.Extensions.Logging;
using Monopoly.GameManagement.Abstract;
using Monopoly.GameManagement.Notifications;
using Monopoly.GameManagement.States;

namespace Monopoly.GameManagement.Handlers;

internal class PlayerLeftNotificationHandler(
    PlayersState playersState,
    IGameHubService hub,
    ILogger<PlayerLeftNotificationHandler> logger
) : INotificationHandler<PlayerLeftNotification>
{
    public async Task Handle(PlayerLeftNotification notification, CancellationToken cancellationToken)
    {
        var player = playersState.GetPlayerById(notification.ConnectionId);
        if (player is null)
        {
            logger.LogWarning("Player with connection id {ConnectionId} not found", notification.ConnectionId);
            return;
        }

        playersState.RemovePlayer(player);

        logger.LogInformation("Player {Id} - {Nickname} left the game", player.Id, player.Nickname);
        await hub.NotifyAllPlayers("PlayerLeft", new { player.Id }, cancellationToken);
    }
}