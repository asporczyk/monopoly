using Microsoft.AspNetCore.SignalR;
using Monopoly.GameManagement;
using Monopoly.GameManagement.Models;

namespace Monopoly.Api.Hubs;

internal sealed class GameHub(ILogger<GameHub> logger) : Hub
{
    public override async Task OnConnectedAsync()
    {
        // Send the connection ID to the client
        await Clients.Caller.SendAsync("ReceiveConnectionId", Context.ConnectionId);
        await base.OnConnectedAsync();
    }

    public async Task JoinGame(string nickname)
    {
        var player = new Player { Id = Context.ConnectionId, Nick = nickname };
        GameHost.AddPlayer(player);
        await Clients.All.SendAsync("PlayerJoined", player);
    }

    public async Task Ready()
    {
        var player = GameHost.Players.First(p => p.Id == Context.ConnectionId);
        player.IsReady = true;

        await Clients.All.SendAsync("PlayerReady", player.Nick);
    }

    public async Task StartGame()
    {
        if (!GameHost.IsEveryoneReady())
        {
            await Clients.Caller.SendAsync("NotEveryoneReady");
            return;
        }

        GameHost.StartGame();
        await Clients.All.SendAsync("GameStarted");
    }
}