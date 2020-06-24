using System.Collections.Generic;
using System.Linq;
using BurglarOfBabylon.Maps;
using RogueSheep;
using RogueSheep.Display;

namespace BurglarOfBabylon
{
    public class GameState
    {
        public Map CurrentMap { get; set; }
        public MapEntity Player { get; set; }

        public GameState()
        {
            Player = new MapEntity("Bob", (58, 58), new GameTile(CP437Glyph.AtSign, RogueColor.Lime));

            var actors = new List<MapEntity>
            {
                Player,
                new MapEntity("Random guard", (11, 10), new GameTile(CP437Glyph.CapitalG, RogueColor.DarkMagenta)),
                new MapEntity("Another random guard", (52, 52), new GameTile(CP437Glyph.CapitalG, RogueColor.Magenta))
            };

            var mapObjects = Office.Tiles.Select(t => TileDefinitions.MapObjectMapping[t]).ToArray();

            CurrentMap = new Map(mapObjects, actors);
        }
    }
}
