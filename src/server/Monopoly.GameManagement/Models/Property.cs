namespace Monopoly.GameManagement.Models;

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

    // TODO: Don't throw exceptions
    // TODO: Buy property
    // TODO: Buy house
    // TODO: Buy hotel
    // TODO: Pay rent
    // TODO: Sell house
}