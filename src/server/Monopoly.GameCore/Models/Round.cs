namespace Monopoly.GameCore.Models;

public class Round
{
    public int CurrentRound { get; private set; }

    public int CurrentPlayerIndex { get; private set; }

    public void NextPlayer() => CurrentPlayerIndex++;

    public void ResetPlayer() => CurrentPlayerIndex = 0;

    public void NextRound() => CurrentRound++;

    public void ResetRound() => CurrentRound = 0;
}