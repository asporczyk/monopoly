using MediatR;

namespace Monopoly.GameManagement.Notifications;

public record BuyHotelNotification(string ConnectionId) : INotification;