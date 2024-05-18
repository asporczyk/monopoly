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
    public bool HasHotel { get; set; }
    public string? OwnerId { get; set; }

    public int CalculateRentToPay()
    {
        if (HasHotel)
        {
            return HotelCost;
        }

        if (Houses > 0)
        {
            return Rent * Houses;
        }

        return Rent;
    }
}