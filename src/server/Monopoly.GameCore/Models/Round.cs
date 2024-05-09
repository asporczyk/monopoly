namespace Monopoly.GameCore.Models;

public class Round
{
    public int CurrentRound { get; private set; }

    public int CurrentOrderIndex { get; private set; }

    public void NextPlayer() => CurrentOrderIndex++;

    public void ResetPlayer() => CurrentOrderIndex = 0;

    public void NextRound() => CurrentRound++;

    public void ResetRound() => CurrentRound = 0;
}