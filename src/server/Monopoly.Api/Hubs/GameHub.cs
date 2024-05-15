using MediatR;
using Microsoft.AspNetCore.SignalR;
using Monopoly.GameManagement.Notifications;

namespace Monopoly.Api.Hubs;

internal sealed class GameHub(IPublisher mediator) : Hub
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
        => await mediator.Publish(new MovePlayerNotification(Context.ConnectionId, steps));

    public async Task BuyField() =>
        await mediator.Publish(new BuyFieldNotification(Context.ConnectionId));

    public async Task EndTurn() =>
        await mediator.Publish(new EndTurnNotification(Context.ConnectionId));

    public async Task PayBail() =>
        await mediator.Publish(new PayBailNotification(Context.ConnectionId));

    public async Task LeaveJail() =>
        await mediator.Publish(new LeaveJailNotification(Context.ConnectionId));

    public async Task BuyHouse() =>
        await mediator.Publish(new BuyHouseNotification(Context.ConnectionId));

    // TODO: Buy hotels

    public async Task CommunityChestField() =>
        await mediator.Publish(new CommunityChestFieldNotification(Context.ConnectionId));

    public async Task ChanceField() =>
        await mediator.Publish(new ChanceFieldNotification(Context.ConnectionId));
}