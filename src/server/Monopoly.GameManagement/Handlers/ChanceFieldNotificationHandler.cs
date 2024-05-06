using MediatR;
using Monopoly.GameManagement.Notifications;

namespace Monopoly.GameManagement.Handlers;

public class ChanceFieldNotificationHandler(
) : INotificationHandler<ChanceFieldNotification>
{
    public Task Handle(ChanceFieldNotification notification, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}