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
            if (mover == gameState.Player && gameState.CurrentMapName != MapData.Office.Name)
            {
                gameState.ChangeMap(MapData.Office);
                return true;
            }
            else if (mover == gameState.Player && gameState.CurrentMapName == MapData.Office.Name && gameState.Player.Inventory.Any(i => i.Template == ItemDefinitions.StolenData))
            {
                gameState.ChangeMap(MapData.Floor38);
                gameState.Messages.Push("You have stolen the data and escaped alive! You have won!");
                gameState.Messages.Push("Congratulations!");
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

        public static bool StealData(Actor? stealer, Point2i _, GameState gameState)
        {
            if (stealer != gameState.Player)
            {
                return false;
            }

            gameState.Player.Inventory.Add(new Item(ItemDefinitions.StolenData));
            gameState.Messages.Push("You have stolen the data! Now get out!");
            return true;
        }
    }
}
