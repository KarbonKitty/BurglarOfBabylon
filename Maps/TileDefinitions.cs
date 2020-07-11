using System.Collections.Generic;
using RogueSheep;
using RogueSheep.Display;

namespace BurglarOfBabylon.Maps
{
    public static class TileDefinitions
    {
        public static readonly MapObject Floor = new MapObject("floor", "Floor covered in cheap plastic rug, the staple of office spaces everywhere.", new GameTile(CP437Glyph.SmallDot, Colors.PlasticBlue));
        public static readonly MapObject Wall = new MapObject("wall", "Simple, but sturdy, wall.", new GameTile(CP437Glyph.Hash, Colors.PlasticBlue), false, false);
        public static readonly MapObject Bed = new MapObject("bed", "Almost as comfortable as sleeping on a rock.", new GameTile(CP437Glyph.Equals, Colors.PlasticBlue));
        public static readonly MapObject Door = new MapObject("door", "Closed door made out of a plastic slab.", new GameTile(CP437Glyph.Plus, Colors.PlasticBlue), false, false, Interactions.OpenDoor);
        public static readonly MapObject OpenDoor = new MapObject("open door", "Open door made out of a plastic slab.", new GameTile(CP437Glyph.Slash, Colors.PlasticBlue), true, true, Interactions.CloseDoor);
        public static readonly MapObject Table = new MapObject("table", "Small table made out of a light-blue plastic, omnipresent in the LiviCubes.", new GameTile(CP437Glyph.SetSum, Colors.PlasticBlue), false, true);
        public static readonly MapObject Chair = new MapObject("chair", "This plastic chair is standard eqiupment in LiviCubes. It is always surprising to everybody who uses those how comfortable they are - in stark contrast to the rest of furniture here.", new GameTile(CP437Glyph.SingleHorizontalLineDoubleDown, Colors.PlasticBlue));
        public static readonly MapObject Sink = new MapObject("sink", "You can wash your hands in this sink.", new GameTile(CP437Glyph.SuperscriptO, Colors.PlasticBlue));
        public static readonly MapObject Toilet = new MapObject("toilet", "A toilet.", new GameTile(CP437Glyph.SpanishQuestionMark, Colors.PlasticBlue), true, true);
        public static readonly MapObject Shower = new MapObject("shower", "Shower cabin. Surprisingly spacious.", new GameTile(CP437Glyph.Root, Colors.PlasticBlue));
        public static readonly MapObject Wardrobe = new MapObject("closet", "Wardrobe in the LiviCube is made out of those same plastic slabs that make up walls. It is not surprising, given that it usually doubles as a wall, too.", new GameTile(CP437Glyph.TripleEquals, Colors.PlasticBlue), false, false);
        public static readonly MapObject Counter = new MapObject("counter", "Basic counter, mounted on wall hinges.", new GameTile(CP437Glyph.Negation, Colors.PlasticBlue), false, true);
        public static readonly MapObject Nightstand = new MapObject("nightstand", "Tiny nightstand, made out of the omnipresent light-blue plastic.", new GameTile(CP437Glyph.ReverseNegation, Colors.PlasticBlue), false, true);
        public static readonly MapObject OpenAir = new MapObject("open air", "Open air. Don't fall down.", new GameTile(CP437Glyph.Empty), passable: false, transparent: true);
        public static readonly MapObject StairsUp = new MapObject("stairs up", "This staircase is leading up from here.", new GameTile(CP437Glyph.RightAngleBracket, RogueColor.White));
        public static readonly MapObject StairsDown = new MapObject("stairs down", "This staircase is leading down from here.", new GameTile(CP437Glyph.LeftAngleBracket, RogueColor.White));
        public static readonly MapObject ReinforcedDoor = new MapObject("secure door", "Closed doors made out of steel, with complex lock.", new GameTile(CP437Glyph.PlusMinus, RogueColor.SteelBlue), false, false);
        public static readonly MapObject ElevatorFloor = new MapObject("elevator", "Elevator floor covered in linoleum.", new GameTile(CP437Glyph.Underscore, RogueColor.White));

        public static readonly MapObject OfficeChair = new MapObject("office chair", "Typical gray office chair. Seems comfortable enough.", new GameTile(CP437Glyph.SingleHorizontalLineDoubleDown, RogueColor.Grey));
        public static readonly MapObject OfficeDesk = new MapObject("office desk", "Standard corporate office desk. Slightly, but inoffensievly, off-white.", new GameTile(CP437Glyph.ParagraphEnd, RogueColor.White), false, true);
        public static readonly MapObject StorageCabinet = new MapObject("office storage cabinet", "Wooden storage cabinet, full of old-school, dead-tree documents.", new GameTile(CP437Glyph.TripleEquals, RogueColor.SandyBrown), false, false);
        public static readonly MapObject Mainframe = new MapObject("mainframe", "VLC, or Very Large Computer. In reality, most likely a bunch of normally-sized computers in a trench coat.", new GameTile(CP437Glyph.Sun, RogueColor.Silver), false, false);
        public static readonly MapObject LowDoor = new MapObject("low door", "Waist height door. Closed.", new GameTile(CP437Glyph.SteppingStone, RogueColor.RosyBrown), false, true);
        public static readonly MapObject OfficePlant = new MapObject("office plant", "Rare example of something actually alive being in this office, an lush green plant. LED lights seem to agree with it.", new GameTile(CP437Glyph.Spade, RogueColor.DarkGreen), false, false);

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
            { '/', OpenDoor },
            { '±', ReinforcedDoor },
            { 'h', OfficeChair },
            { 'D', OfficeDesk },
            { 'C', StorageCabinet },
            { 'M', Mainframe },
            { '_', ElevatorFloor },
            { 'P', OfficePlant },
            { ',', LowDoor }
        };
    }
}
