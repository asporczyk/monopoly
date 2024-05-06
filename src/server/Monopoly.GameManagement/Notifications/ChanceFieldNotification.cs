using MediatR;

namespace Monopoly.GameManagement.Notifications;

public record ChanceFieldNotification(string ConnectionId) : INotification;