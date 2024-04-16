using Monopoly.GameCore.Models;
using Monopoly.GameLogic.Generators;

namespace Monopoly.GameManagement.States;

public static class GameState
{
    public static Game Game { get; } = new();

    public static void Reset()
    {
        Game.Reset();
        RoundState.ResetRound();
    }

    public static void StartGame()
    {
        Game.Start();
        RoundState.ResetRound();
        BoardState.Fields = FieldsGenerator.GenerateGameFields();
    }
}