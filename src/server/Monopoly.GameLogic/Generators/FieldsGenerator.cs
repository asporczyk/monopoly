using Monopoly.GameCore.Models;
using static Monopoly.GameCore.Dictionary.SpecialFields;

namespace Monopoly.GameLogic.Generators;

public static class FieldsGenerator
{
    public static List<Field> GenerateGameFields() =>
    [
        new Field { Position = 0, SpecialField = Go }, // START
        new Field
        {
            Position = 1,
            Property = new Property { Name = "Old Kent Road", Price = 60, Rent = 2, HouseCost = 50, HotelCost = 50 }
        },
        new Field { Position = 2, SpecialField = CommunityChest }, // Community Chest
        new Field
        {
            Position = 3,
            Property = new Property { Name = "Whitechapel Road", Price = 60, Rent = 4, HouseCost = 50, HotelCost = 50 }
        },
        new Field { Position = 4, SpecialField = IncomeTax }, // Income Tax
        new Field
        {
            Position = 5,
            Property = new Property
                { Name = "Kings Cross Station", Price = 200, Rent = 25, HouseCost = 0, HotelCost = 0 }
        },
        new Field
        {
            Position = 6,
            Property = new Property
                { Name = "The Angel Islington", Price = 100, Rent = 6, HouseCost = 50, HotelCost = 50 }
        },
        new Field { Position = 7, SpecialField = Chance }, // Chance
        new Field
        {
            Position = 8,
            Property = new Property { Name = "Euston Road", Price = 100, Rent = 6, HouseCost = 50, HotelCost = 50 }
        },
        new Field
        {
            Position = 9,
            Property = new Property { Name = "Pentonville Road", Price = 120, Rent = 8, HouseCost = 50, HotelCost = 50 }
        },
        new Field { Position = 10, SpecialField = JailVisit }, // Jail/Just Visiting
        new Field
        {
            Position = 11,
            Property = new Property { Name = "Pall Mall", Price = 140, Rent = 10, HouseCost = 100, HotelCost = 100 }
        },
        new Field
        {
            Position = 12,
            Property = new Property { Name = "Electric Company", Price = 150, Rent = 0, HouseCost = 0, HotelCost = 0 }
        },
        new Field
        {
            Position = 13,
            Property = new Property { Name = "Whitehall", Price = 140, Rent = 10, HouseCost = 100, HotelCost = 100 }
        },
        new Field
        {
            Position = 14,
            Property = new Property
                { Name = "Northumberland Avenue", Price = 160, Rent = 12, HouseCost = 100, HotelCost = 100 }
        },
        new Field
        {
            Position = 15,
            Property = new Property
                { Name = "Marylebone Station", Price = 200, Rent = 25, HouseCost = 0, HotelCost = 0 }
        },
        new Field
        {
            Position = 16,
            Property = new Property { Name = "Bow Street", Price = 180, Rent = 14, HouseCost = 100, HotelCost = 100 }
        },
        new Field { Position = 17, SpecialField = CommunityChest }, // Community Chest
        new Field
        {
            Position = 18,
            Property = new Property
                { Name = "Marlborough Street", Price = 180, Rent = 14, HouseCost = 100, HotelCost = 100 }
        },
        new Field
        {
            Position = 19,
            Property = new Property { Name = "Vine Street", Price = 200, Rent = 16, HouseCost = 100, HotelCost = 100 }
        },
        new Field { Position = 20, SpecialField = FreeParking }, // Free Parking
        new Field
        {
            Position = 21,
            Property = new Property { Name = "Strand", Price = 220, Rent = 18, HouseCost = 150, HotelCost = 150 }
        },
        new Field { Position = 22, SpecialField = Chance }, // Chance
        new Field
        {
            Position = 23,
            Property = new Property { Name = "Fleet Street", Price = 220, Rent = 18, HouseCost = 150, HotelCost = 150 }
        },
        new Field
        {
            Position = 24,
            Property = new Property
                { Name = "Trafalgar Square", Price = 240, Rent = 20, HouseCost = 150, HotelCost = 150 }
        },
        new Field
        {
            Position = 25,
            Property = new Property
                { Name = "Fenchurch St Station", Price = 200, Rent = 25, HouseCost = 0, HotelCost = 0 }
        },
        new Field
        {
            Position = 26,
            Property = new Property
                { Name = "Leicester Square", Price = 260, Rent = 22, HouseCost = 150, HotelCost = 150 }
        },
        new Field
        {
            Position = 27,
            Property = new Property
                { Name = "Coventry Street", Price = 260, Rent = 22, HouseCost = 150, HotelCost = 150 }
        },
        new Field
        {
            Position = 28,
            Property = new Property { Name = "Water Works", Price = 150, Rent = 0, HouseCost = 0, HotelCost = 0 }
        },
        new Field
        {
            Position = 29,
            Property = new Property { Name = "Piccadilly", Price = 280, Rent = 24, HouseCost = 150, HotelCost = 150 }
        },
        new Field { Position = 30, SpecialField = GoToJail }, // Go To Jail
        new Field
        {
            Position = 31,
            Property = new Property { Name = "Regent Street", Price = 300, Rent = 26, HouseCost = 200, HotelCost = 200 }
        },
        new Field
        {
            Position = 32,
            Property = new Property { Name = "Oxford Street", Price = 300, Rent = 26, HouseCost = 200, HotelCost = 200 }
        },
        new Field { Position = 33, SpecialField = CommunityChest }, // Community Chest
        new Field
        {
            Position = 34,
            Property = new Property { Name = "Bond Street", Price = 320, Rent = 28, HouseCost = 200, HotelCost = 200 }
        },
        new Field
        {
            Position = 35,
            Property = new Property
                { Name = "Liverpool St Station", Price = 200, Rent = 25, HouseCost = 0, HotelCost = 0 }
        },
        new Field { Position = 36, SpecialField = Chance }, // Chance
        new Field
        {
            Position = 37,
            Property = new Property { Name = "Park Lane", Price = 350, Rent = 35, HouseCost = 200, HotelCost = 200 }
        },
        new Field { Position = 38, SpecialField = IncomeTax }, // Super Tax
        new Field
        {
            Position = 39,
            Property = new Property { Name = "Mayfair", Price = 400, Rent = 50, HouseCost = 200, HotelCost = 200 }
        }
    ];
}