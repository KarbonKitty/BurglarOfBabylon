using System.Collections.Generic;
using BurglarOfBabylon.Items;
using RogueSheep;

namespace BurglarOfBabylon.Maps
{
    public class MapDefinition
    {
        public string Name { get; }
        public Point2i PlayerStartingPosition { get; }
        public IReadOnlyCollection<Actor> NPCs { get; }
        public IReadOnlyDictionary<Point2i, Item> Items { get; }
        public string Tiles { get; }

        public MapDefinition(string name, Point2i startingPosition, Actor[] NPCs, Dictionary<Point2i, Item> items, string tiles)
        {
            Name = name;
            PlayerStartingPosition = startingPosition;
            this.NPCs = NPCs;
            Items = items;
            Tiles = tiles;
        }
    }
}
