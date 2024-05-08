using MediatR;

namespace Monopoly.GameManagement.Notifications;

public record PlayerLeftNotification(string ConnectionId) : INotification;