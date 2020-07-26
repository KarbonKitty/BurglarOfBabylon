using System.Linq;
using BurglarOfBabylon.Items;
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

        public static bool MoveToNewMap(Actor? mover, Point2i portalPosition, GameState gameState)
        {
            if (mover != null && mover == gameState.Player && gameState.CurrentMapName != MapData.Office.Name)
            {
                gameState.ChangeMap(MapData.Office);
                return true;
            }
            return false;
        }

        public static bool OpenSecureDoor(Actor? opener, Point2i doorPosition, GameState gameState)
        {
            if (opener is null)
            {
                return false;
            }
            else if (opener.Inventory.Any(i => i.Template == ItemDefinitions.Keycard))
            {
                gameState.CurrentMap.ReplaceObject(doorPosition, TileDefinitions.OpenDoor);
            }
            else if (opener == gameState.Player)
            {
                gameState.Messages.Push("You can't open those doors without a keycard.");
            }
            return true;
        }
    }
}
