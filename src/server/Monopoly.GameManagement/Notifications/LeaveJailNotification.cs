using MediatR;

namespace Monopoly.GameManagement.Notifications;

public record LeaveJailNotification(string ConnectionId) : INotification;