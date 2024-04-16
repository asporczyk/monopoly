namespace Monopoly.GameLogic;

public static class Jail
{
    private const int JailBail = 50;

    // TODO: Fix reference
    public static void GoToJail(Player player)
    {
        player.IsInJail = true;
        player.JailTurns = 3;
        player.Position = 10;
    }

    public static void LeaveJail(Player player)
    {
        player.IsInJail = false;
        player.JailTurns = 0;
    }

    public static void StayInJail(Player player)
    {
        player.JailTurns--;
    }

    public static void PayBail(Player player)
    {
        player.Money -= JailBail;
        LeaveJail(player);
    }
}