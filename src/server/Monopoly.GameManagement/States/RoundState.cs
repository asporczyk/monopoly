using Microsoft.Extensions.Logging;
using Monopoly.GameCore.Models;

namespace Monopoly.GameManagement.States;

public class RoundState(PlayersState playersState, ILogger<RoundState> logger)
{
    private const int MaxRounds = 40;
    private Round Round { get; set; } = new();

    public bool IsOver() => Round.CurrentRound >= MaxRounds;

    public void NextPlayer()
    {
        if (Round.CurrentPlayerIndex >= playersState.Players.Count - 1)
        {
            Round.ResetPlayer();
            Round.NextRound();

            logger.LogInformation("Next round");
        }
        else
        {
            Round.NextPlayer();

            logger.LogInformation("Next player");
        }
    }

    public void ResetPlayer() => Round.ResetPlayer();

    public void NextRound() => Round.NextRound();

    public void ResetRound() => Round.ResetRound();

    public int GetCurrentRound() => Round.CurrentRound;

    public int GetCurrentPlayerIndex() => Round.CurrentPlayerIndex;
}