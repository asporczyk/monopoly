using MediatR;

namespace Monopoly.GameManagement.Notifications;

public record JoinGameNotification(string ConnectionId, string? Nickname) : INotification;