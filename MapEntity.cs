using RogueSheep;
using RogueSheep.Display;
using RogueSheep.Maps;

namespace BurglarOfBabylon
{
    public class MapEntity : IHasPosition, IPresentable
    {
        public string Name { get; }
        public Point2i Position { get; private set; }
        public GameTile Presentation { get; }

        public MapEntity(string name, Point2i position, GameTile presentation)
        {
            Name = name;
            Position = position;
            Presentation = presentation;
        }

        public void Move(Point2i vector)
        {
            Position += vector;
        }
    }
}
