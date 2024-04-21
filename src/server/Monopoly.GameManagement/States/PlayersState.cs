using Microsoft.Extensions.Logging;
using Monopoly.GameCore.Models;
using Monopoly.GameLogic.Helpers;

namespace Monopoly.GameManagement.States;

public class PlayersState(ILogger<PlayersState> logger)
{
    public List<Player> Players { get; } = [];

    public Player? GetPlayerById(string id) => Players.FirstOrDefault(p => p.Id == id);

    public Player AddPlayer(string id, string? nickname)
    {
        logger.LogInformation("Adding player with id {Id} and nickname {Nickname}", id, nickname);

        var player = new Player(nickname ?? NicknameGenerator.Generate(), id);
        Players.Add(player);

        return player;
    }

    public void RemovePlayer(Player player)
    {
        logger.LogInformation("Removing player with id {Id}", player.Id);
        Players.Remove(player);
    }

    public bool IsEveryoneReady() => Players.All(p => p.IsReady);

    public void Reset() => Players.Clear();
}