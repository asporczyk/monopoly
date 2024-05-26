using MediatR;

namespace Monopoly.GameManagement.Notifications;

public record ResetGameNotification(string ConnectionId) : INotification;