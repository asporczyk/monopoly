using MediatR;
using Microsoft.Extensions.Logging;
using Monopoly.GameLogic.Services;
using Monopoly.GameManagement.Abstract;
using Monopoly.GameManagement.Notifications;
using Monopoly.GameManagement.States;

namespace Monopoly.GameManagement.Handlers;

public class EndTurnNotificationHandler(
    PlayersState playersState,
    RoundState roundState,
    GameState gameState,
    IGameHubService hub,
    ILogger<EndTurnNotificationHandler> logger
) : INotificationHandler<EndTurnNotification>
{
    public async Task Handle(EndTurnNotification notification, CancellationToken cancellationToken)
    {
        var player = playersState.GetPlayerById(notification.ConnectionId);
        switch (player)
        {
            case null:
                logger.LogWarning("Player with connection id {ConnectionId} not found", notification.ConnectionId);
                return;
            case { IsInJail: true }:
            {
                player.JailTurns--;
                if (player.JailTurns == 0)
                {
                    JailService.LeaveJail(player);
                    await hub.NotifyAllPlayers("PlayerLeftJail", new { player.Nickname }, cancellationToken);
                }

                break;
            }
        }

        roundState.NextTurn();

        // TODO: Maybe print the player who is next
        await hub.NotifyAllPlayers("NextPlayer", cancellationToken);
        await hub.NotifyPlayer(gameState.GetCurrentPlayerId(), "YourTurn", cancellationToken);
    }
}