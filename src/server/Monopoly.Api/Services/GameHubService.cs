using Microsoft.AspNetCore.SignalR;
using Monopoly.Api.Hubs;
using Monopoly.GameManagement.Abstract;

namespace Monopoly.Api.Services;

internal class GameHubService(IHubContext<GameHub> hubContext) : IGameHubService
{
    public Task NotifyAllPlayers(string methodName, object? data, CancellationToken cancellationToken) =>
        hubContext.Clients.All.SendAsync(methodName, data, cancellationToken);
}