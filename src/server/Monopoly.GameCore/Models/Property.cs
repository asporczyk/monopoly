using Serilog;

namespace Monopoly.GameCore.Models;

public class Property
{
    private static readonly ILogger Log = Serilog.Log.ForContext(typeof(Property));

    public string Name { get; init; } = null!;
    public int Price { get; init; }
    public int Rent { get; init; }
    public int HouseCost { get; init; }
    public int HotelCost { get; init; }
    public int Houses { get; set; }
    public bool HasHotel { get; private set; }
    public string? OwnerId { get; private set; }

    public bool Buy(Player player)
    {
        if (OwnerId != null)
        {
            Log.Information("Property {Name} is already owned by {OwnerId}", Name, OwnerId);
            return false;
        }

        if (player.Money < Price)
        {
            Log.Information("Player {PlayerId} does not have enough money to buy {Name}", player.Id, Name);
            return false;
        }

        player.Money -= Price;
        OwnerId = player.Id;
        return true;
    }

    public void Sell(Player player)
    {
        if (OwnerId != player.Id)
        {
            Log.Information("Player {PlayerId} does not own {Name}", player.Id, Name);
            return;
        }

        player.Money += Price;
        OwnerId = null;
    }

    public void BuyHouse(Player player)
    {
        if (OwnerId != player.Id)
        {
            Log.Information("Player {PlayerId} does not own {Name}", player.Id, Name);
            return;
        }

        if (player.Money < HouseCost)
        {
            Log.Information("Player {PlayerId} does not have enough money to buy a house for {Name}", player.Id, Name);
            return;
        }

        player.Money -= HouseCost;
        Houses++;
    }

    public void BuyHotel(Player player)
    {
        if (OwnerId != player.Id)
        {
            Log.Information("Player {PlayerId} does not own {Name}", player.Id, Name);
            return;
        }

        if (player.Money < HotelCost)
        {
            Log.Information("Player {PlayerId} does not have enough money to buy a hotel for {Name}", player.Id, Name);
            return;
        }

        if (Houses < 4)
        {
            Log.Information("Player {PlayerId} does not have enough houses to buy a hotel for {Name}", player.Id, Name);
            return;
        }

        if (HasHotel)
        {
            Log.Information("Player {PlayerId} already has a hotel for {Name}", player.Id, Name);
            return;
        }

        Houses = 0;

        player.Money -= HotelCost;
        HasHotel = true;
    }

    public void PayRent(Player player, Player owner)
    {
        if (OwnerId == null)
        {
            Log.Information("Property {Name} is not owned", Name);
            return;
        }

        if (OwnerId == player.Id)
        {
            Log.Information("Player {PlayerId} owns {Name}", player.Id, Name);
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
        owner.Money += rent;
    }
}