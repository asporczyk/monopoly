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
    // TODO: Endgame logic, print player with most money
    public Game Game { get; } = new();

    public string GetCurrentPlayerId() => playersState.Players[roundState.GetCurrentPlayerIndex()].Id;

    public Player GetCurrentPlayer() => playersState.Players[roundState.GetCurrentPlayerIndex()];

    public void Reset()
    {
        logger.LogInformation("Resetting game state...");

        Game.Reset();
        roundState.ResetRound();
    }

    public void StartGame()
    {
        logger.LogInformation("Starting game...");

        Game.Start();
        roundState.ResetRound();
        roundState.ResetPlayer();
        boardState.Fields = FieldsGenerator.GenerateGameFields();
    }
}