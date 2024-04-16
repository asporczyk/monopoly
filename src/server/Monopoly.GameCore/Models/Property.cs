namespace Monopoly.GameCore.Models;

public class Property
{
    public string Name { get; init; } = null!;
    public int Price { get; init; }
    public int Rent { get; init; }
    public int HouseCost { get; init; }
    public int HotelCost { get; init; }
    public int Houses { get; set; } = 0;
    public bool HasHotel { get; private set; }
    public string? OwnerId { get; private set; }

    public void Buy(Player player)
    {
        if (OwnerId != null)
        {
            return;
        }

        if (player.Money < Price)
        {
            return;
        }

        player.Money -= Price;
        OwnerId = player.Id;
    }

    public void Sell(Player player)
    {
        if (OwnerId != player.Id)
        {
            return;
        }

        player.Money += Price;
        OwnerId = null;
    }

    public void BuyHouse(Player player)
    {
        if (OwnerId != player.Id)
        {
            return;
        }

        if (player.Money < HouseCost)
        {
            return;
        }

        player.Money -= HouseCost;
        Houses++;
    }

    public void BuyHotel(Player player)
    {
        if (OwnerId != player.Id)
        {
            return;
        }

        if (player.Money < HotelCost)
        {
            return;
        }

        if (Houses < 4)
        {
            return;
        }

        if (HasHotel)
        {
            return;
        }

        Houses = 0;

        player.Money -= HotelCost;
        HasHotel = true;
    }

    public void PayRent(Player player)
    {
        if (OwnerId == null)
        {
            return;
        }

        if (OwnerId == player.Id)
        {
            return;
        }

        // TODO: Change logic for houses and hotels
        var rent = Rent;
        if (Houses > 0)
        {
            rent *= Houses;
        }
        else if (HasHotel)
        {
            rent = HotelCost;
        }

        player.Money -= rent;
    }
}