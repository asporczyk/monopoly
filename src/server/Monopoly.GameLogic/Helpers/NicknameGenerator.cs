namespace Monopoly.GameLogic.Helpers;

public static class NicknameGenerator
{
    private static readonly Random Random = new();

    private static readonly string[] Adjectives =
    [
        "Fast", "Sneaky", "Mighty", "Dark", "Clever", "Brave", "Silent", "Ancient", "Golden", "Frozen"
    ];

    private static readonly string[] Nouns =
    [
        "Warrior", "Mage", "Rogue", "Paladin", "Hunter", "Druid", "Necromancer", "Bard", "Pirate", "Knight"
    ];

    public static string Generate()
    {
        var adjective = Adjectives[Random.Next(Adjectives.Length)];
        var noun = Nouns[Random.Next(Nouns.Length)];
        var number = Random.Next(100);

        return $"{adjective}{noun}{number}";
    }
}