using Monopoly.GameCore.Models;

namespace Monopoly.GameManagement.States;

public static class RoundState
{
    private const int MaxRounds = 40;
    private static Round Round { get; set; } = new();

    public static bool IsOver() => Round.CurrentRound >= MaxRounds;

    public static void NextPlayer()
    {
        if (Round.CurrentPlayer >= PlayersState.Players.Count - 1)
        {
            Round.ResetPlayer();
            Round.NextRound();
        }
        else
        {
            Round.NextPlayer();
        }
    }

    public static void ResetPlayer() => Round.ResetPlayer();

    public static void NextRound() => Round.NextRound();

    public static void ResetRound() => Round.ResetRound();

    public static int GetCurrentRound() => Round.CurrentRound;

    public static int GetCurrentPlayer() => Round.CurrentPlayer;
}