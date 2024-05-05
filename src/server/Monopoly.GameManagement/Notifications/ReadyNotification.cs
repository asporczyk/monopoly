using MediatR;

namespace Monopoly.GameManagement.Notifications;

public record ReadyNotification(string ConnectionId) : INotification;