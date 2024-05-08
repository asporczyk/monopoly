using MediatR;
using Monopoly.GameManagement.Notifications;

namespace Monopoly.GameManagement.Handlers;

public class CommunityChestFieldNotificationHandler(
) : INotificationHandler<CommunityChestFieldNotification>
{
    public Task Handle(CommunityChestFieldNotification notification, CancellationToken cancellationToken)
    {

        throw new NotImplementedException();
    }
}