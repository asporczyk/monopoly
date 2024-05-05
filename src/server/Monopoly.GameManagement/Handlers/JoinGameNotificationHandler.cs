using MediatR;
using Microsoft.Extensions.Logging;
using Monopoly.GameCore.Models;
using Monopoly.GameLogic.Helpers;
using Monopoly.GameManagement.Abstract;
using Monopoly.GameManagement.Notifications;
using Monopoly.GameManagement.States;

namespace Monopoly.GameManagement.Handlers;

internal class JoinGameNotificationHandler(
    PlayersState playersState,
    IGameHubService hub,
    ILogger<JoinGameNotificationHandler> logger
) : INotificationHandler<JoinGameNotification>
{
    public async Task Handle(JoinGameNotification notification, CancellationToken cancellationToken)
    {
        if (playersState.GetPlayerById(notification.ConnectionId) is not null)
        {
            logger.LogWarning(
                "Player with connection id {ConnectionId} already joined the game",
                notification.ConnectionId
            );
            return;
        }

        var nickname = string.IsNullOrWhiteSpace(notification.Nickname)
            ? NicknameGenerator.Generate()
            : notification.Nickname;
        var id = notification.ConnectionId;

        playersState.AddPlayer(new Player(nickname, id));

        logger.LogInformation("Player {Id} - {Nickname} joined the game", id, nickname);
        await hub.NotifyAllPlayers("PlayerJoined", new { playersState.Players }, cancellationToken);
    }
}