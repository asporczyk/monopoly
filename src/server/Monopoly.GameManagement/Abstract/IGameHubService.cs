namespace Monopoly.GameManagement.Abstract;

public interface IGameHubService
{
    Task NotifyAllPlayers(string methodName, object data, CancellationToken ct = default);
    Task NotifyAllPlayers(string methodName, CancellationToken ct = default);
    Task NotifyPlayer(string connectionId, string methodName, CancellationToken ct = default);
    Task NotifyPlayer(string connectionId, string methodName, object data, CancellationToken ct = default);
}