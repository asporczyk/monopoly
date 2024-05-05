using Microsoft.AspNetCore.SignalR;
using Monopoly.Api.Hubs;
using Monopoly.GameManagement.Abstract;

namespace Monopoly.Api.Services;

internal class GameHubService(IHubContext<GameHub> hubContext) : IGameHubService
{
    public Task NotifyAllPlayers(string methodName, object data, CancellationToken ct = default) =>
        hubContext.Clients.All.SendAsync(methodName, data, ct);

    public Task NotifyAllPlayers(string methodName, CancellationToken ct = default) =>
        hubContext.Clients.All.SendAsync(methodName, ct);

    public Task NotifyPlayer(string connectionId, string methodName, CancellationToken ct = default) =>
        hubContext.Clients.Client(connectionId).SendAsync(methodName, ct);

    public Task NotifyPlayer(string connectionId, string methodName, object data, CancellationToken ct = default) =>
        hubContext.Clients.Client(connectionId).SendAsync(methodName, data, ct);
}