using MediatR;

namespace Monopoly.GameManagement.Notifications;

public record StartGameNotification(string ConnectionId) : INotification;