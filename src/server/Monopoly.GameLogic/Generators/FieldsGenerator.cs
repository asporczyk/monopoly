using Monopoly.GameCore.Models;
using static Monopoly.GameCore.Dictionary.SpecialFields;

namespace Monopoly.GameLogic.Generators;

public static class FieldsGenerator
{
    public static List<Field> GenerateGameFields()
    {
        return
        [
            new Field { Position = 0, SpecialField = Go }, // START
            new Field
            {
                Position = 1,
                Property = new Property
                    { Name = "San Diego Drive", Price = 60, Rent = 2, HouseCost = 50, HotelCost = 50 }
            },
            new Field { Position = 2, SpecialField = CommunityChest }, // Community Chest
            new Field
            {
                Position = 3,
                Property = new Property { Name = "Kansas Drive", Price = 90, Rent = 4, HouseCost = 50, HotelCost = 50 }
            },
            new Field { Position = 4, SpecialField = IncomeTax }, // Income Tax
            new Field
            {
                Position = 5,
                Property = new Property
                    { Name = "Beverly Railroad", Price = 200, Rent = 25, HouseCost = 0, HotelCost = 0 }
            },
            new Field
            {
                Position = 6,
                Property = new Property
                    { Name = "Vermont Drive", Price = 120, Rent = 6, HouseCost = 50, HotelCost = 50 }
            },
            new Field { Position = 7, SpecialField = Chance }, // Chance
            new Field
            {
                Position = 8,
                Property = new Property
                    { Name = "Phoenix Drive", Price = 130, Rent = 6, HouseCost = 50, HotelCost = 50 }
            },
            new Field
            {
                Position = 9,
                Property = new Property { Name = "Boston Drive", Price = 150, Rent = 8, HouseCost = 50, HotelCost = 50 }
            },
            new Field { Position = 10, SpecialField = JailVisit }, // Jail/Just Visiting
            new Field
            {
                Position = 11,
                Property = new Property
                    { Name = "Olivia Gardens", Price = 140, Rent = 10, HouseCost = 100, HotelCost = 100 }
            },
            new Field
            {
                Position = 12,
                Property = new Property { Name = "Car Company", Price = 150, Rent = 0, HouseCost = 0, HotelCost = 0 }
            },
            new Field
            {
                Position = 13,
                Property = new Property
                    { Name = "California Drive", Price = 160, Rent = 10, HouseCost = 100, HotelCost = 100 }
            },
            new Field
            {
                Position = 14,
                Property = new Property
                    { Name = "States Drive", Price = 140, Rent = 12, HouseCost = 100, HotelCost = 100 }
            },
            new Field
            {
                Position = 15,
                Property = new Property
                    { Name = "Manhattan railroad", Price = 200, Rent = 25, HouseCost = 0, HotelCost = 0 }
            },
            new Field
            {
                Position = 16,
                Property = new Property
                    { Name = "Bethany Drive", Price = 180, Rent = 14, HouseCost = 100, HotelCost = 100 }
            },
            new Field { Position = 17, SpecialField = CommunityChest }, // Community Chest
            new Field
            {
                Position = 18,
                Property = new Property
                    { Name = "New York Drive", Price = 200, Rent = 14, HouseCost = 100, HotelCost = 100 }
            },
            new Field
            {
                Position = 19,
                Property = new Property
                    { Name = "Atlanta Drive", Price = 200, Rent = 16, HouseCost = 100, HotelCost = 100 }
            },
            new Field { Position = 20, SpecialField = FreeParking }, // Free Parking
            new Field
            {
                Position = 21,
                Property = new Property
                    { Name = "Almond Drive", Price = 200, Rent = 18, HouseCost = 150, HotelCost = 150 }
            },
            new Field { Position = 22, SpecialField = Chance }, // Chance
            new Field
            {
                Position = 23,
                Property = new Property
                    { Name = "Clemnet Drive", Price = 200, Rent = 18, HouseCost = 150, HotelCost = 150 }
            },
            new Field
            {
                Position = 24,
                Property = new Property
                    { Name = "Pacific Drive", Price = 260, Rent = 20, HouseCost = 150, HotelCost = 150 }
            },
            new Field
            {
                Position = 25,
                Property = new Property
                    { Name = "Water Works", Price = 60, Rent = 25, HouseCost = 0, HotelCost = 0 }
            },
            new Field
            {
                Position = 26,
                Property = new Property
                    { Name = "Rodeo Drive", Price = 260, Rent = 22, HouseCost = 150, HotelCost = 150 }
            },
            new Field
            {
                Position = 27,
                Property = new Property
                    { Name = "Nashville Drive", Price = 260, Rent = 22, HouseCost = 150, HotelCost = 150 }
            },
            new Field
            {
                Position = 28,
                Property = new Property { Name = "Railroad", Price = 130, Rent = 0, HouseCost = 0, HotelCost = 0 }
            },
            new Field
            {
                Position = 29,
                Property = new Property { Name = "Oakville", Price = 230, Rent = 24, HouseCost = 150, HotelCost = 150 }
            },
            new Field { Position = 30, SpecialField = GoToJail }, // Go To Jail
            new Field
            {
                Position = 31,
                Property = new Property
                    { Name = "Atlantic Drive", Price = 300, Rent = 26, HouseCost = 200, HotelCost = 200 }
            },
            new Field
            {
                Position = 32,
                Property = new Property
                    { Name = "Clement Drive", Price = 300, Rent = 26, HouseCost = 200, HotelCost = 200 }
            },
            new Field { Position = 33, SpecialField = CommunityChest }, // Community Chest
            new Field
            {
                Position = 34,
                Property = new Property { Name = "Riverside", Price = 250, Rent = 28, HouseCost = 200, HotelCost = 200 }
            },
            new Field
            {
                Position = 35,
                Property = new Property
                    { Name = "Short line", Price = 200, Rent = 25, HouseCost = 0, HotelCost = 0 }
            },
            new Field { Position = 36, SpecialField = Chance }, // Chance
            new Field
            {
                Position = 37,
                Property = new Property
                    { Name = "Folklore Heights", Price = 200, Rent = 35, HouseCost = 200, HotelCost = 200 }
            },
            new Field { Position = 38, SpecialField = IncomeTax }, // Super Tax
            new Field
            {
                Position = 39,
                Property = new Property { Name = "Salt Lake", Price = 350, Rent = 50, HouseCost = 200, HotelCost = 400 }
            }
        ];
    }
}