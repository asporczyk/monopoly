using Microsoft.Extensions.Logging;
using Monopoly.GameCore.Models;
using Monopoly.GameLogic.Generators;

namespace Monopoly.GameManagement.States;

public class GameState(RoundState roundState, BoardState boardState, ILogger<GameState> logger)
{
    public Game Game { get; } = new();

    public void Reset()
    {
        logger.LogInformation("Resetting game state");
        Game.Reset();
        roundState.ResetRound();
    }

    public void StartGame()
    {
        logger.LogInformation("Starting game");
        Game.Start();
        roundState.ResetRound();
        boardState.Fields = FieldsGenerator.GenerateGameFields();
    }
}