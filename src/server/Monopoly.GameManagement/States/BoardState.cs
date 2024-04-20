using Monopoly.GameCore.Models;

namespace Monopoly.GameManagement.States;

public static class BoardState
{
    public const int TotalFields = 40;
    public const int JailPosition = 10;
    public const int GoPosition = 0;
    public const int GoMoney = 200;
    public static List<Field> Fields { get; set; } = [];
}