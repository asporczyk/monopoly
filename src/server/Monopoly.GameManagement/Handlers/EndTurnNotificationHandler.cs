using MediatR;
using Microsoft.Extensions.Logging;
using Monopoly.GameLogic.Services;
using Monopoly.GameManagement.Abstract;
using Monopoly.GameManagement.Notifications;
using Monopoly.GameManagement.States;

namespace Monopoly.GameManagement.Handlers;

public class EndTurnNotificationHandler(
    RoundState roundState,
    GameState gameState,
    IGameHubService hub,
    ILogger<EndTurnNotificationHandler> logger
) : INotificationHandler<EndTurnNotification>
{
    public async Task Handle(EndTurnNotification notification, CancellationToken cancellationToken)
    {
        var player = gameState.GetCurrentPlayer();
        if (player.Id != notification.ConnectionId)
        {
            logger.LogWarning("Player {Id} - {Nickname} is not the current player", player.Id, player.Nickname);
            return;
        }

        if (player is { IsInJail: true })
        {
            player.JailTurns--;
            if (player.JailTurns == 0)
            {
                JailService.LeaveJail(player);

                logger.LogInformation("Player {Id} - {Nickname} left jail", player.Id, player.Nickname);
                await hub.NotifyAllPlayers("PlayerLeftJail", new { player.Id }, cancellationToken);
            }
        }

        var round = roundState.GetCurrentRound();
        roundState.NextTurn();

        if (roundState.IsGameOver())
        {
            var winnerId = gameState.GetWinner();
            await hub.NotifyAllPlayers("Winner", winnerId, cancellationToken);
            logger.LogInformation("Game over, winner is {Id}", winnerId);
            gameState.Reset();
            return;
        }

        var nextRound = roundState.GetCurrentRound();
        if (nextRound != round)
        {
            await hub.NotifyAllPlayers("NextRound", nextRound, cancellationToken);
        }

        logger.LogInformation("Player {Id} - {Nickname} ended turn", player.Id, player.Nickname);

        var currentPlayerId = gameState.GetCurrentPlayerId();
        await hub.NotifyAllPlayers("NextPlayer", new { currentPlayerId }, cancellationToken);
        await hub.NotifyPlayer(currentPlayerId, "YourTurn", cancellationToken);
    }
}