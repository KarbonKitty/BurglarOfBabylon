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

            var floor = new MapObject(new GameTile(CP437Glyph.SmallDot, RogueColor.Grey));
            var wall = new MapObject(new GameTile(CP437Glyph.Hash, RogueColor.DarkGrey), passable: false, transparent: false);

            var mapObjects = new MapObject[GameConsts.MapWidth * GameConsts.MapHeight];
            for (var i = 0; i < mapObjects.Length; i++)
            {
                if (i % GameConsts.MapWidth == 0 || i % GameConsts.MapWidth == GameConsts.MapWidth - 1
                    || i / GameConsts.MapHeight == 0 || i / GameConsts.MapHeight == GameConsts.MapHeight - 1)
                {
                    mapObjects[i] = wall;
                }
                else
                {
                    mapObjects[i] = floor;
                }
            }

            CurrentMap = new Map(mapObjects, actors);
        }
    }
}
