using MediatR;
using Microsoft.Extensions.Logging;
using Monopoly.GameManagement.Abstract;
using Monopoly.GameManagement.Notifications;
using Monopoly.GameManagement.States;

namespace Monopoly.GameManagement.Handlers;

internal class StartGameNotificationHandler(
    GameState gameState,
    PlayersState playersState,
    IGameHubService hub,
    ILogger<StartGameNotificationHandler> logger
) : INotificationHandler<StartGameNotification>
{
    public async Task Handle(StartGameNotification notification, CancellationToken cancellationToken)
    {
        var id = notification.ConnectionId;
        if (!playersState.IsEveryoneReady())
        {
            await hub.NotifyPlayer(id, "PlayersNotReady", cancellationToken);
            return;
        }

        if (gameState.Game.IsRunning)
        {
            await hub.NotifyPlayer(id, "GameAlreadyStarted", cancellationToken);
            return;
        }

        gameState.StartGame();
        logger.LogInformation("Game started");
        await hub.NotifyAllPlayers("GameStarted", cancellationToken);

        var currentPlayerId = gameState.GetCurrentPlayerId();
        logger.LogInformation("Current player: - {CurrentPlayerId}", currentPlayerId);
        await hub.NotifyPlayer(currentPlayerId, "YourTurn", cancellationToken);
    }
}