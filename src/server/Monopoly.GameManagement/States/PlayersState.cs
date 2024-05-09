using Monopoly.GameCore.Models;

namespace Monopoly.GameManagement.States;

public class PlayersState
{
    public List<Player> Players { get; } = [];


    public Player? GetPlayerById(string id) => Players.FirstOrDefault(p => p.Id == id);

    public void AddPlayer(Player player) => Players.Add(player);

    public void RemovePlayer(Player player) => Players.Remove(player);

    public bool IsEveryoneReady() => Players.All(p => p.IsReady);
}