using Monopoly.GameCore.Models;
using Monopoly.GameLogic.Generators;
using Serilog;

namespace Monopoly.GameManagement.States;

public static class GameState
{
    private static readonly ILogger Log = Serilog.Log.ForContext(typeof(GameState));
    public static Game Game { get; } = new();

    public static void Reset()
    {
        Log.Information("Resetting game state");
        Game.Reset();
        RoundState.ResetRound();
    }

    public static void StartGame()
    {
        Log.Information("Starting game");
        Game.Start();
        RoundState.ResetRound();
        BoardState.Fields = FieldsGenerator.GenerateGameFields();
    }
}