using MediatR;

namespace Monopoly.GameManagement.Notifications;

public record BuyFieldNotification(string ConnectionId) : INotification;