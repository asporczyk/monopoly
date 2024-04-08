using Microsoft.AspNetCore.SignalR;

namespace Monopoly.Api.Hubs;

internal sealed class GameHub(ILogger<GameHub> logger) : Hub
{
    public override async Task OnConnectedAsync()
    {
        // Send the connection ID to the client
        await Clients.Client(Context.ConnectionId).SendAsync("ReceiveConnectionId", Context.ConnectionId);
        await base.OnConnectedAsync();
    }

    // TODO: Add methods to handle game logic

    // TODO: Remove this method, it's just an example
    public async Task SendMessage(MessageDto message)
    {
        logger.LogInformation("Received message from {User}: {Message}", message.User, message.Message);
        await Clients.All.SendAsync("ReceiveMessage", message);
    }
}

public record MessageDto(string? User, string? Message);