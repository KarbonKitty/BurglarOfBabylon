using RogueSheep;

namespace BurglarOfBabylon
{
    public class MapEntity
    {
        public Point2i Position { get; private set; }
        public MapTile Appearance { get; private set; }

        public MapEntity(Point2i position, MapTile appearance)
        {
            Position = position;
            Appearance = appearance;
        }

        public void Move(Point2i vector)
        {
            Position += vector;
        }

        public void ChangeAppearance(MapTile newAppearance)
        {
            Appearance = newAppearance;
        }
    }
}
