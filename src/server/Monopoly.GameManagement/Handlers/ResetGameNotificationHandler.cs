using MediatR;
using Microsoft.Extensions.Logging;
using Monopoly.GameManagement.Abstract;
using Monopoly.GameManagement.Notifications;
using Monopoly.GameManagement.States;

namespace Monopoly.GameManagement.Handlers;

internal class ResetGameNotificationHandler(GameState gameState, IGameHubService hub, ILogger<ResetGameNotificationHandler> logger)
    : INotificationHandler<ResetGameNotification>
{
    public async Task Handle(ResetGameNotification notification, CancellationToken cancellationToken)
    {
        // TODO: Validate if the player is the host
        gameState.Reset();

        logger.LogInformation("Game has been reset by {PlayerId}", notification.ConnectionId);
        await hub.NotifyAllPlayers("GameReset", cancellationToken);
    }
}