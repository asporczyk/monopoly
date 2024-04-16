using Monopoly.GameManagement.Models;

namespace Monopoly.GameManagement;

public static class GameHost
{
    public static int Round { get; private set; } = 1;

    public static bool IsGameRunning { get; private set; }

    public static readonly List<Player> Players = [];

    public static void StartGame() => IsGameRunning = true;

    public static void StopGame() => IsGameRunning = false;

    public static void AddPlayer(Player player) => Players.Add(player);

    public static void RemovePlayer(Player player) => Players.Remove(player);

    public static void NextRound() => Round++;

    public static bool IsEveryoneReady() => Players.All(p => p.IsReady);
}