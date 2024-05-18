using MediatR;

namespace Monopoly.GameManagement.Notifications;

public record BuyHouseNotification(string ConnectionId) : INotification;