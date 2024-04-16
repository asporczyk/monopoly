using Monopoly.GameCore.Models;
using Monopoly.GameLogic.Helpers;
using Serilog;

namespace Monopoly.GameManagement.States;

public static class PlayersState
{
    private static readonly ILogger Log = Serilog.Log.ForContext(typeof(PlayersState));

    public static List<Player> Players { get; } = [];

    public static Player? GetPlayerById(string id) => Players.FirstOrDefault(p => p.Id == id);

    public static Player AddPlayer(string id, string? nickname)
    {
        Log.Information("Adding player with id {Id} and nickname {Nickname}", id, nickname);

        var player = new Player(nickname ?? NicknameGenerator.Generate(), id);
        Players.Add(player);

        return player;
    }

    public static void RemovePlayer(Player player)
    {
        Log.Information("Removing player with id {Id}", player.Id);
        Players.Remove(player);
    }

    public static bool IsEveryoneReady() => Players.All(p => p.IsReady);

    public static void Reset() => Players.Clear();
}