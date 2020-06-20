using System.Collections.Generic;
using RogueSheep;
using RogueSheep.Display;

namespace BurglarOfBabylon.Maps
{
    public static class TileDefinitions
    {
        public static readonly MapObject Floor = new MapObject("floor", "just some floor", new GameTile(CP437Glyph.SmallDot, RogueColor.LightGray));
        public static readonly MapObject Wall = new MapObject("wall", "just some wall", new GameTile(CP437Glyph.Hash, Colors.PlasticBlue), false, false);
        public static readonly MapObject Bed = new MapObject("bed", "just a bed", new GameTile(CP437Glyph.Equals, Colors.PlasticBlue));
        public static readonly MapObject Door = new MapObject("door", "just a door", new GameTile(CP437Glyph.Plus, Colors.PlasticBlue), false, false);
        public static readonly MapObject OpenDoor = new MapObject("open door", "just some open door", new GameTile(CP437Glyph.Slash, Colors.PlasticBlue), true, true);
        public static readonly MapObject Table = new MapObject("table", "just a table", new GameTile(CP437Glyph.SetSum, Colors.PlasticBlue), false, true);
        public static readonly MapObject Chair = new MapObject("chair", "just a chair", new GameTile(CP437Glyph.SingleHorizontalLineDoubleDown, Colors.PlasticBlue));
        public static readonly MapObject Sink = new MapObject("sink", "just a sink", new GameTile(CP437Glyph.SuperscriptO, Colors.PlasticBlue));
        public static readonly MapObject Toilet = new MapObject("toilet", "just a toilet", new GameTile(CP437Glyph.SpanishQuestionMark, Colors.PlasticBlue), true, true);
        public static readonly MapObject Shower = new MapObject("shower", "just a shower", new GameTile(CP437Glyph.Root, Colors.PlasticBlue));
        public static readonly MapObject Wardrobe = new MapObject("closet", "just a closet", new GameTile(CP437Glyph.TripleEquals, Colors.PlasticBlue), false, false);
        public static readonly MapObject Counter = new MapObject("counter", "just a counter", new GameTile(CP437Glyph.Negation, Colors.PlasticBlue), false, true);
        public static readonly MapObject Nightstand = new MapObject("nightstand", "just a nightstand", new GameTile(CP437Glyph.ReverseNegation, Colors.PlasticBlue), false, true);
        public static readonly MapObject OpenAir = new MapObject("open air", "just some open air", new GameTile(CP437Glyph.Empty));
        public static readonly MapObject StairsUp = new MapObject("stairs up", "just some stairs up", new GameTile(CP437Glyph.RightAngleBracket, RogueColor.White));
        public static readonly MapObject StairsDown = new MapObject("stairs down", "just some stairs down", new GameTile(CP437Glyph.LeftAngleBracket, RogueColor.White));

        public static readonly Dictionary<char, MapObject> MapObjectMapping = new Dictionary<char, MapObject>{
            { '.', Floor },
            { '#', Wall },
            { '=', Bed },
            { '+', Door },
            { 'T', Table },
            { '4', Chair },
            { 's', Sink },
            { 't', Toilet },
            { 'S', Shower },
            { 'w', Wardrobe },
            { 'c', Counter },
            { 'n', Nightstand },
            { ' ', OpenAir },
            { '>', StairsDown },
            { '<', StairsUp },
            { '/', OpenDoor }
        };
    }
}
