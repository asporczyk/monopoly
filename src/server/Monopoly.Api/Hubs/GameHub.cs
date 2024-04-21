using Microsoft.AspNetCore.SignalR;
using Monopoly.GameLogic.Services;
using Monopoly.GameManagement.States;

namespace Monopoly.Api.Hubs;

internal sealed class GameHub(
    GameState gameState,
    PlayersState playersState,
    BoardState boardState,
    RoundState roundState
) : Hub
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
        var player = playersState.AddPlayer(id, nickname);
        await Clients.All.SendAsync("PlayerJoined", player);
    }

    public async Task Ready()
    {
        var player = playersState.GetPlayerById(Context.ConnectionId);
        if (player != null)
        {
            player.IsReady = true;

            await Clients.All.SendAsync("PlayerReady", player.Nickname);
        }
    }

    public async Task StartGame()
    {
        if (!playersState.IsEveryoneReady())
        {
            await Clients.Caller.SendAsync("NotEveryoneReady");
            return;
        }

        if (gameState.Game.IsRunning)
        {
            await Clients.Caller.SendAsync("GameAlreadyStarted");
            return;
        }

        gameState.StartGame();
        var currentPlayer = playersState.Players[roundState.GetCurrentPlayerIndex()];

        await Clients.All.SendAsync("GameStarted");
        await Clients.Client(currentPlayer.Id).SendAsync("YourTurn");
    }

    public async Task RollDice()
    {
        var player = playersState.GetPlayerById(Context.ConnectionId);
        if (player != null && player.Id == gameState.GetCurrentPlayerId())
        {
            var roll = DiceService.RollDouble();
            BoardState.MovePlayer(player, roll);

            // TODO: Implement field actions
        }
    }

    public async Task BuyTest()
    {
        var player = playersState.GetPlayerById(Context.ConnectionId);
        if (player != null)
        {
            boardState.Fields[3].Property?.Sell(player);
            await Clients.All.SendAsync("PlayerBought", player.Nickname);
        }
    }
}