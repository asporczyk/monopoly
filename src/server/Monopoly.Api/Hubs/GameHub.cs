using MediatR;
using Microsoft.AspNetCore.SignalR;
using Monopoly.GameCore.Models;
using Monopoly.GameLogic.Services;
using Monopoly.GameManagement.Notifications;
using Monopoly.GameManagement.States;

namespace Monopoly.Api.Hubs;

internal sealed class GameHub(
    GameState gameState,
    PlayersState playersState,
    BoardState boardState,
    IMediator mediator
) : Hub
{
    public override async Task OnConnectedAsync()
    {
        await Clients.Caller.SendAsync("ReceiveConnectionId", Context.ConnectionId);
        await base.OnConnectedAsync();
    }

    public override async Task OnDisconnectedAsync(Exception? exception)
    {
        await mediator.Publish(new PlayerLeftNotification(Context.ConnectionId));
        await base.OnDisconnectedAsync(exception);
    }

    public async Task JoinGame(string? nickname) =>
        await mediator.Publish(new JoinGameNotification(Context.ConnectionId, nickname));

    public async Task Ready()
        => await mediator.Publish(new ReadyNotification(Context.ConnectionId));

    public async Task StartGame() =>
        await mediator.Publish(new StartGameNotification(Context.ConnectionId));

    public async Task MovePlayer(int steps)
    {
        var player = ValidateCurrentPlayer(Context.ConnectionId);
        if (player is not null)
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
                // TODO: Chance or Community Chest
                await Clients.Client(player.Id).SendAsync("SpecialFields", "TODO: Chance or Community Chest");
                return;
            }

            if (property.OwnerId is null)
            {
                await Clients.Client(player.Id).SendAsync("CanBuyField", property.Name);
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

    public async Task BuyField() =>
        await mediator.Publish(new BuyFieldNotification(Context.ConnectionId));

    public async Task PayBail()
    {
        var player = ValidateCurrentPlayer(Context.ConnectionId);
        if (player is not null)
        {
            JailService.PayBail(player);

            await Clients.All.SendAsync("PlayerLeftJail", player.Nickname);
        }
    }

    public async Task LeaveJail()
    {
        var player = ValidateCurrentPlayer(Context.ConnectionId);
        if (player is not null)
        {
            JailService.LeaveJail(player);

            await Clients.All.SendAsync("PlayerLeftJail", player.Nickname);
        }
    }

    public async Task EndTurn() =>
        await mediator.Publish(new EndTurnNotification(Context.ConnectionId));

    private Player? ValidateCurrentPlayer(string connectionId)
    {
        var player = playersState.GetPlayerById(connectionId);
        if (player is not null && player.Id == gameState.GetCurrentPlayerId())
        {
            return player;
        }

        return null;
    }

    // TODO: SpecialFields
}