using Microsoft.Extensions.Logging;
using Monopoly.GameCore.Models;
using Monopoly.GameLogic.Generators;

namespace Monopoly.GameManagement.States;

public class GameState(
    RoundState roundState,
    BoardState boardState,
    PlayersState playersState,
    ILogger<GameState> logger
)
{
    public Game Game { get; } = new();

    public string GetCurrentPlayerId() => roundState.PlayersOrder[roundState.GetCurrentOrderIndex()];

    public Player GetCurrentPlayer() => playersState.Players.First(p => p.Id == GetCurrentPlayerId());

    public void Reset()
    {
        logger.LogInformation("Resetting game state...");
        roundState.GeneratePlayersOrder();
        Game.Reset();
        roundState.ResetRound();
    }

    public void StartGame()
    {
        logger.LogInformation("Starting game...");

        Game.Start();
        roundState.GeneratePlayersOrder();
        roundState.ResetRound();
        roundState.ResetPlayer();
        boardState.Fields = FieldsGenerator.GenerateGameFields();
    }

    public string GetWinner() => playersState.Players.OrderByDescending(p => p.Money).First().Id;
}