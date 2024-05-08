using MediatR;

namespace Monopoly.GameManagement.Notifications;

public record EndTurnNotification(string ConnectionId) : INotification;