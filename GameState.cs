using System.Collections.Generic;
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
            Player = new MapEntity("Bob", (4, 4), new GameTile(CP437Glyph.AtSign, RogueColor.Lime));

            var actors = new List<MapEntity>
            {
                Player,
                new MapEntity("Random guard", (12, 12), new GameTile(CP437Glyph.CapitalG, RogueColor.DarkMagenta))
            };

            var mapObjects = new MapObject[GameConsts.MapWidth * GameConsts.MapHeight];
            for (var i = 0; i < mapObjects.Length; i++)
            {
                mapObjects[i] = new MapObject(new GameTile(CP437Glyph.SmallDot, RogueColor.Grey));
            }

            CurrentMap = new Map(mapObjects, actors);
        }
    }
}
