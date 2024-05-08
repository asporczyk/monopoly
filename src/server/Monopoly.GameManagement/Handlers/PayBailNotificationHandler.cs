using MediatR;
using Microsoft.Extensions.Logging;
using Monopoly.GameLogic.Services;
using Monopoly.GameManagement.Abstract;
using Monopoly.GameManagement.Notifications;
using Monopoly.GameManagement.States;

namespace Monopoly.GameManagement.Handlers;

public class PayBailNotificationHandler(
    GameState gameState,
    IGameHubService hub,
    ILogger<PayBailNotificationHandler> logger
) : INotificationHandler<PayBailNotification>
{
    public async Task Handle(PayBailNotification notification, CancellationToken cancellationToken)
    {
        var player = gameState.GetCurrentPlayer();
        if (player.Id != notification.ConnectionId)
        {
            logger.LogWarning("Player {Id} - {Nickname} is not the current player", player.Id, player.Nickname);
            return;
        }

        var isBailPayed = JailService.PayBail(player);
        if (!isBailPayed)
        {
            logger.LogWarning("Player {Id} - {Nickname} does not have enough money to pay bail", player.Id, player.Nickname);
            return;
        }

        logger.LogInformation("{Id} - {Nickname} paid bail", player.Id, player.Nickname);
        await hub.NotifyAllPlayers("PlayerLeftJail", new { player.Id }, cancellationToken);
    }
}