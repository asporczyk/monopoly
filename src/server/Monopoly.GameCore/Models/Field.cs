using Monopoly.GameCore.Dictionary;

namespace Monopoly.GameCore.Models;

public class Field
{
    public int Position { get; init; }

    public Property? Property { get; init; }

    public SpecialFields? SpecialField { get; init; }
}