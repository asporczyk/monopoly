using MediatR;
using Microsoft.Extensions.Logging;
using Monopoly.GameManagement.Abstract;
using Monopoly.GameManagement.Notifications;
using Monopoly.GameManagement.States;

namespace Monopoly.GameManagement.Handlers;

internal class ReadyNotificationHandler(
    PlayersState playersState,
    IGameHubService hub,
    ILogger<ReadyNotificationHandler> logger
) : INotificationHandler<ReadyNotification>
{
    public async Task Handle(ReadyNotification notification, CancellationToken cancellationToken)
    {
        var player = playersState.GetPlayerById(notification.ConnectionId);
        if (player is null)
        {
            logger.LogWarning("Player with connection id {ConnectionId} not found", notification.ConnectionId);
            return;
        }

        player.IsReady = true;

        logger.LogInformation("Player {Id} - {Nickname} is ready", player.Id, player.Nickname);
        await hub.NotifyAllPlayers("PlayerReady", new { player.Id }, cancellationToken);
    }
}