using System.Collections.Generic;
using BurglarOfBabylon.Maps;
using RogueSheep;
using RogueSheep.Display;
using RogueSheep.Maps;

namespace BurglarOfBabylon
{
    public class Map : GameMapBase<MapEntity>
    {
        public Map(IMapTile[] tiles, IEnumerable<MapEntity> actors)
            : base(tiles,
                GameConsts.MapWidth,
                actors,
                new MapObject("hidden", "this is hidden from view",
                    new GameTile(CP437Glyph.AlmostEquals,
                        Colors.InvisibleLightGrey,
                        Colors.InvisibleDarkGrey)))
        { }
    }
}
