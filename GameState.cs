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
            Player = new MapEntity("Bob", (2, 16), new GameTile(CP437Glyph.AtSign, RogueColor.Lime));

            var actors = new List<MapEntity>
            {
                Player,
                new MapEntity("Random guard", (7, 16), new GameTile(CP437Glyph.CapitalG, RogueColor.DarkMagenta))
            };

            var mapObjects = Floor38.Tiles.Select(t => TileDefinitions.MapObjectMapping[t]).ToArray();

            CurrentMap = new Map(mapObjects, actors);
        }
    }
}
