using MediatR;

namespace Monopoly.GameManagement.Notifications;

public record CommunityChestFieldNotification(string ConnectionId) : INotification;