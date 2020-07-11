using RogueSheep;

namespace BurglarOfBabylon.Maps
{
    public static class Interactions
    {
        public static bool OpenDoor(Actor? opener, Point2i doorPosition, GameState gameState)
        {
            gameState.CurrentMap.ReplaceObject(doorPosition, TileDefinitions.OpenDoor);
            return true;
        }

        public static bool CloseDoor(Actor? closer, Point2i doorPosition, GameState gameState)
        {
            gameState.CurrentMap.ReplaceObject(doorPosition, TileDefinitions.Door);
            return true;
        }
    }
}
