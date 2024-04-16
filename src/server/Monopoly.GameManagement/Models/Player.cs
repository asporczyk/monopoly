using Monopoly.GameManagement.Helpers;

namespace Monopoly.GameManagement.Models;

public class Player
{
    public string? Nick
    {
        get => _nick;
        init => _nick = !string.IsNullOrEmpty(value) ? value : NicknameGenerator.Generate();
    }

    private readonly string _nick = null!;
    public string Id { get; init; } = null!;
    public int Money { get; set; } = 1500;
    public int Position { get; set; } = 0;
    public int Order { get; set; } = GameState.Players.Count;
    public bool IsInJail { get; set; }
    public int JailTurns { get; set; } = 0;
    public bool IsBankrupt { get; set; }
    public bool IsReady { get; set; }

    // public bool IsInGame { get; set; }
    // public bool IsTurn { get; set; }
    // public bool IsWinner { get; set; }
    // public bool IsLoser { get; set; }
}