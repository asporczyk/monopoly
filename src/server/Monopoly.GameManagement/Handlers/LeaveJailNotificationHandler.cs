using MediatR;
using Microsoft.Extensions.Logging;
using Monopoly.GameLogic.Services;
using Monopoly.GameManagement.Abstract;
using Monopoly.GameManagement.Notifications;
using Monopoly.GameManagement.States;

namespace Monopoly.GameManagement.Handlers;

public class LeaveJailNotificationHandler(
    GameState gameState,
    IGameHubService hub,
    ILogger<LeaveJailNotificationHandler> logger
) : INotificationHandler<LeaveJailNotification>
{
    public async Task Handle(LeaveJailNotification notification, CancellationToken cancellationToken)
    {
        var player = gameState.GetCurrentPlayer();
        if (player.Id != notification.ConnectionId)
        {
            logger.LogWarning("Player {Id} - {Nickname} is not the current player", player.Id, player.Nickname);
            return;
        }

        JailService.LeaveJail(player);

        logger.LogInformation("Player {Id} - {Nickname} left jail", player.Id, player.Nickname);
        await hub.NotifyAllPlayers("PlayerLeftJail", new { player.Id }, cancellationToken);
    }
}