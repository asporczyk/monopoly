using MediatR;
using Microsoft.Extensions.Logging;
using Monopoly.GameLogic.Services;
using Monopoly.GameManagement.Abstract;
using Monopoly.GameManagement.Notifications;
using Monopoly.GameManagement.States;

namespace Monopoly.GameManagement.Handlers;

public class LeaveJailNotificationHandler(
    PlayersState playersState,
    IGameHubService hub,
    ILogger<LeaveJailNotificationHandler> logger
) : INotificationHandler<LeaveJailNotification>
{
    public async Task Handle(LeaveJailNotification notification, CancellationToken cancellationToken)
    {
        var player = playersState.GetPlayerById(notification.ConnectionId);
        if (player is null)
        {
            logger.LogWarning("Player with connection id {ConnectionId} not found", notification.ConnectionId);
            return;
        }

        JailService.LeaveJail(player);

        logger.LogInformation("Player {Id} - {Nickname} left jail", player.Id, player.Nickname);
        await hub.NotifyAllPlayers("PlayerLeftJail", new { player.Id }, cancellationToken);
    }
}