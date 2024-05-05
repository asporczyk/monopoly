using MediatR;
using Microsoft.Extensions.Logging;
using Monopoly.GameLogic.Services;
using Monopoly.GameManagement.Abstract;
using Monopoly.GameManagement.Notifications;
using Monopoly.GameManagement.States;

namespace Monopoly.GameManagement.Handlers;

public class PayBailNotificationHandler(
    PlayersState playersState,
    IGameHubService hub,
    ILogger<PayBailNotificationHandler> logger
) : INotificationHandler<PayBailNotification>
{
    public async Task Handle(PayBailNotification notification, CancellationToken cancellationToken)
    {
        var player = playersState.GetPlayerById(notification.ConnectionId);
        if (player is null)
        {
            logger.LogWarning("Player with connection id {ConnectionId} not found", notification.ConnectionId);
            return;
        }

        JailService.PayBail(player);
        logger.LogInformation("{Id} - {Nickname} paid bail", player.Id, player.Nickname);
        await hub.NotifyAllPlayers("PlayerLeftJail", new { player.Id }, cancellationToken);
    }
}