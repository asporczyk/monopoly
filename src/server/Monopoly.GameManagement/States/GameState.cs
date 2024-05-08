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

    public string GetCurrentPlayerId() => playersState.Players[roundState.GetCurrentPlayerIndex()].Id;

    public Player GetCurrentPlayer() => playersState.Players[roundState.GetCurrentPlayerIndex()];

    public void Reset()
    {
        logger.LogInformation("Resetting game state...");

        Game.Reset();
        roundState.ResetRound();
    }

    // TODO: At start create players order, if player is bankrupt remove from order
    // TODO: If player is bankrupt remove his cards
    // TODO: Use Order list to get next player, order can be listed players ids
    public void StartGame()
    {
        logger.LogInformation("Starting game...");

        Game.Start();
        roundState.ResetRound();
        roundState.ResetPlayer();
        boardState.Fields = FieldsGenerator.GenerateGameFields();
    }

    public string GetWinner() => playersState.Players.OrderByDescending(p => p.Money).First().Id;
}