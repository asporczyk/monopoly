namespace Monopoly.GameManagement.Abstract;

public interface IGameHubService
{
    Task NotifyAllPlayers(string methodName, object? data, CancellationToken cancellationToken);
}