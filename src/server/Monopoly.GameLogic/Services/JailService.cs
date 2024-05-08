using Monopoly.GameCore.Models;

namespace Monopoly.GameLogic.Services;

public static class JailService
{
    private const int JailBail = 50;

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

    public static bool PayBail(Player player)
    {
        if (player.Money < JailBail)
        {
            return false;
        }

        player.Money -= JailBail;
        LeaveJail(player);
        return true;
    }
}