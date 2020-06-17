using RogueSheep.Display;
using RogueSheep.Maps;

namespace BurglarOfBabylon
{
    public class MapObject : IMapTile
    {
        public GameTile Presentation { get; }
        public bool Passable { get; }
        public bool Transparent { get; }

        public MapObject(GameTile presentation, bool passable = true, bool transparent = true)
        {
            Presentation = presentation;
            Passable = passable;
            Transparent = transparent;
        }
    }
}
