using Monopoly.GameCore.Models;

namespace Monopoly.GameManagement.States;

public class BoardState
{
    private const int TotalFields = 40;
    private const int GoMoney = 200;
    public const int GoPosition = 0;
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

    public Field? GetField(int position) => Fields.FirstOrDefault(f => f.Position == position);

    public void RemovePlayerCards(string playerId)
    {
        foreach (var field in Fields)
        {
            if (field.Property is null || field.Property.OwnerId != playerId)
            {
                continue;
            }

            field.Property.OwnerId = null;
            field.Property.Houses = 0;
            field.Property.HasHotel = false;
        }
    }
}