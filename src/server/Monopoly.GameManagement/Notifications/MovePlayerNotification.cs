using MediatR;

namespace Monopoly.GameManagement.Notifications;

public record MovePlayerNotification(string ConnectionId, int Steps) : INotification;