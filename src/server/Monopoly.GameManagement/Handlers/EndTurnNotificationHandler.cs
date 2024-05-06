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

        roundState.NextTurn();

        logger.LogInformation("Player {Id} - {Nickname} ended turn", player.Id, player.Nickname);
        // TODO: Maybe print the player who is next
        await hub.NotifyAllPlayers("NextPlayer", cancellationToken);
        await hub.NotifyPlayer(gameState.GetCurrentPlayerId(), "YourTurn", cancellationToken);
    }
}