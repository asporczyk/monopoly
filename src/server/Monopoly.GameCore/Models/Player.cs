namespace Monopoly.GameCore.Models;

public class Player(string nickname, string id)
{
    public string Nickname { get; init; } = nickname;
    public string Id { get; init; } = id;

    public int Money { get; set; } = 1500;

    public int Position { get; set; } = 0;

    public int Order { get; set; }

    public bool IsInJail { get; set; }

    public int JailTurns { get; set; } = 0;

    public bool IsBankrupt => Money < 0;

    public bool IsReady { get; set; }

    // public bool IsInGame { get; set; }
    // public bool IsTurn { get; set; }
    // public bool IsWinner { get; set; }
    // public bool IsLoser { get; set; }
}