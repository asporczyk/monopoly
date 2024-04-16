using Monopoly.GameCore.Models;
using Monopoly.GameLogic.Helpers;

namespace Monopoly.GameManagement.States;

public static class PlayersState
{
    public static List<Player> Players { get; } = [];

    public static Player? GetPlayerById(string id) => Players.FirstOrDefault(p => p.Id == id);

    public static Player AddPlayer(string id, string? nickname)
    {
        var player = new Player(nickname ?? NicknameGenerator.Generate(), id);
        Players.Add(player);

        return player;
    }

    public static void RemovePlayer(Player player) => Players.Remove(player);

    public static bool IsEveryoneReady() => Players.All(p => p.IsReady);

    public static void Reset() => Players.Clear();
}