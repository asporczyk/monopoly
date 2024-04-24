using Monopoly.GameCore.Models;

namespace Monopoly.GameManagement.States;

public class BoardState
{
    public const int TotalFields = 40;
    public const int JailPosition = 10;
    public const int GoPosition = 0;
    public const int GoMoney = 200;
    public List<Field> Fields { get; set; } = [];

    public void MovePlayer(Player player, int steps)
    {
        player.Position += steps;
        if (player.Position < TotalFields)
        {
            return;
        }

        player.Position -= TotalFields;
        player.Money += GoMoney;
    }
}