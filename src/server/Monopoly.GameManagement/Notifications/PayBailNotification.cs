using MediatR;

namespace Monopoly.GameManagement.Notifications;

public record PayBailNotification(string ConnectionId) : INotification;