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
        await Clients.Caller.SendAsync("ReceiveConnectionId", Context.ConnectionId);
        await base.OnConnectedAsync();
    }

    public override async Task OnDisconnectedAsync(Exception? exception)
    {
        var player = playersState.GetPlayerById(Context.ConnectionId);
        if (player is not null)
        {
            await Clients.All.SendAsync("PlayerLeft", player.Nickname);
            playersState.RemovePlayer(player);
        }

        await base.OnDisconnectedAsync(exception);
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
        if (player is not null)
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
        var currentPlayerId = gameState.GetCurrentPlayerId();

        await Clients.All.SendAsync("GameStarted");
        await Clients.Client(currentPlayerId).SendAsync("YourTurn");
    }

    public async Task MovePlayer(int steps)
    {
        var player = playersState.GetPlayerById(Context.ConnectionId);
        if (player is not null && player.Id == gameState.GetCurrentPlayerId())
        {
            boardState.MovePlayer(player, steps);

            await Clients.All.SendAsync("PlayerMoved", player.Nickname, steps);

            if (player.Position == BoardState.JailPosition)
            {
                JailService.GoToJail(player);

                await Clients.All.SendAsync("PlayerInJail", player.Nickname);
                return;
            }

            var property = boardState.Fields[player.Position].Property;
            if (property is null)
            {
                await Clients.Client(player.Id).SendAsync("SpecialFields", "TODO: Chance or Community Chest");
                return;
            }

            if (property.OwnerId is null)
            {
                await Clients.Client(player.Id).SendAsync("BuyField", property.Name);
                return;
            }

            var owner = playersState.GetPlayerById(property.OwnerId);
            if (owner is not null)
            {
                property.PayRent(player, owner);

                await Clients.Client(player.Id).SendAsync("PayRent", owner.Nickname, property.Rent);
                await Clients.Client(owner.Id).SendAsync("ReceiveRent", player.Nickname, property.Rent);
            }
        }
    }

    public async Task EndTurn()
    {
        var player = playersState.GetPlayerById(Context.ConnectionId);
        if (player is not null && player.Id == gameState.GetCurrentPlayerId())
        {
            #region TODO: Verify this logic

            if (player is { IsInJail: true })
            {
                player.JailTurns--;
            }

            #endregion

            roundState.EndTurn();

            await Clients.All.SendAsync("NextPlayer");
            await Clients.Client(gameState.GetCurrentPlayerId()).SendAsync("YourTurn");
        }
    }

    // TODO: BuyField
    // TODO: SpecialFields
    // TODO: ExitJail
    // TODO: PayJail
}