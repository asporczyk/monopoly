namespace Monopoly.GameCore.Models;

public class Player(string nickname, string id)
{
    public string Nickname { get; } = nickname;
    public string Id { get; } = id;

    public int Money { get; set; } = 1500;

    public int Position { get; set; }

    public bool IsInJail { get; set; }

    public int JailTurns { get; set; }

    public bool IsBankrupt { get; set; }

    public bool IsReady { get; set; }
}