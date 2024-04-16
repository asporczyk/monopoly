namespace Monopoly.GameLogic;

public static class Dice
{
    private static readonly Random Random = new();

    public static int Roll() => Random.Next(1, 7);
    public static int RollDouble() => Random.Next(1, 7) + Random.Next(1, 7);
}