namespace Monopoly.GameCore.Models;

public class Round
{
    public int CurrentRound { get; private set; }

    public int CurrentPlayer { get; private set; }

    public void NextPlayer() => CurrentPlayer++;

    public void ResetPlayer() => CurrentPlayer = 0;

    public void NextRound() => CurrentRound++;

    public void ResetRound() => CurrentRound = 0;
}