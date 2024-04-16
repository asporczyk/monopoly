using Microsoft.AspNetCore.SignalR;
using Monopoly.GameManagement.States;

namespace Monopoly.Api.Hubs;

internal sealed class GameHub : Hub
{
    public override async Task OnConnectedAsync()
    {
        // Send the connection ID to the client
        await Clients.Caller.SendAsync("ReceiveConnectionId", Context.ConnectionId);
        await base.OnConnectedAsync();
    }

    public async Task JoinGame(string nickname)
    {
        var id = Context.ConnectionId;
        var player = PlayersState.AddPlayer(nickname, id);
        await Clients.All.SendAsync("PlayerJoined", player);
    }

    public async Task Ready()
    {
        var player = PlayersState.GetPlayerById(Context.ConnectionId);
        if (player != null)
        {
            player.IsReady = true;

            await Clients.All.SendAsync("PlayerReady", player.Nickname);
        }
    }

    public async Task StartGame()
    {
        if (!PlayersState.IsEveryoneReady())
        {
            await Clients.Caller.SendAsync("NotEveryoneReady");
            return;
        }

        GameState.StartGame();
        await Clients.All.SendAsync("GameStarted");
    }
}