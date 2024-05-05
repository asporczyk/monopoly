using Microsoft.Extensions.Logging;
using Monopoly.GameCore.Models;

namespace Monopoly.GameManagement.States;

public class PlayersState(ILogger<PlayersState> logger)
{
    public List<Player> Players { get; } = [];

    public Player? GetPlayerById(string id) => Players.FirstOrDefault(p => p.Id == id);

    public void AddPlayer(Player player) => Players.Add(player);

    public void RemovePlayer(Player player)
    {
        logger.LogInformation("Removing player with id {Id}", player.Id);
        Players.Remove(player);
    }

    public bool IsEveryoneReady() => Players.All(p => p.IsReady);

    public void Reset() => Players.Clear();
}