using Microsoft.Extensions.Logging;
using Monopoly.GameCore.Models;

namespace Monopoly.GameManagement.States;

public class RoundState(PlayersState playersState, ILogger<RoundState> logger)
{
    private const int MaxRounds = 20;
    private Round Round { get; set; } = new();

    public List<string> PlayersOrder { get; } = [];

    public bool IsGameOver() => Round.CurrentRound >= MaxRounds;

    public void NextTurn()
    {
        if (Round.CurrentOrderIndex >= PlayersOrder.Count - 1)
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

    public void ResetRound() => Round.ResetRound();

    public int GetCurrentRound() => Round.CurrentRound;

    public int GetCurrentOrderIndex() => Round.CurrentOrderIndex;

    public void GeneratePlayersOrder()
    {
        PlayersOrder.Clear();
        PlayersOrder.AddRange(playersState.Players.Select(p => p.Id));
    }

    public void BankruptPlayer(Player player)
    {
        player.IsBankrupt = true;
        PlayersOrder.Remove(player.Id);
        if (Round.CurrentOrderIndex >= PlayersOrder.Count)
        {
            Round.ResetPlayer();
        }
    }
}