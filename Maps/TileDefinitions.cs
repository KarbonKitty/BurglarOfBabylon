using System.Collections.Generic;
using RogueSheep;
using RogueSheep.Display;

namespace BurglarOfBabylon.Maps
{
    public static class TileDefinitions
    {
        public static readonly MapObject Floor = new MapObject("floor", "just some floor", new GameTile(CP437Glyph.SmallDot, RogueColor.LightGray));
        public static readonly MapObject Wall = new MapObject("wall", "just some wall", new GameTile(CP437Glyph.Hash, RogueColor.DarkGrey), false, false);
        public static readonly MapObject Bed = new MapObject("bed", "just a bed", new GameTile(CP437Glyph.Equals, Colors.PlasticBlue));

        public static readonly Dictionary<char, MapObject> MapObjectMapping = new Dictionary<char, MapObject>{
            { '.', Floor },
            { '#', Wall },
            { '=', Bed }
        };
    }
}
