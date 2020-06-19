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

        public MapObject(string name, string description, GameTile presentation, bool passable = true, bool transparent = true)
        {
            Name = name;
            Description = description;
            Presentation = presentation;
            Passable = passable;
            Transparent = transparent;
        }
    }
}
