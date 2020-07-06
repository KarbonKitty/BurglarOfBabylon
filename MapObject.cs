using System;
using RogueSheep;
using RogueSheep.Display;
using RogueSheep.Maps;

namespace BurglarOfBabylon
{
    public class MapObject : IMapTile
    {
        public string Name { get; }
        public string Description { get; }
        public GameTile Presentation { get; }
        public bool Passable { get; }
        public bool Transparent { get; }
        public Func<Actor?, Point2i, GameState, bool>? Interaction { get; }

        public MapObject(
            string name,
            string description,
            GameTile presentation,
            bool passable = true,
            bool transparent = true,
            Func<Actor?, Point2i, GameState, bool>? interaction = null)
        {
            Name = name;
            Description = description;
            Presentation = presentation;
            Passable = passable;
            Transparent = transparent;
            Interaction = interaction;
        }
    }
}
