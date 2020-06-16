using RogueSheep;

namespace BurglarOfBabylon
{
    public class MapTile
    {
        public CP437Glyph Glyph { get; set; }
        public RogueColor Color { get; set; }

        public MapTile(CP437Glyph glyph, RogueColor? color = null)
        {
            Glyph = glyph;
            Color = color ?? RogueColor.White;
        }
    }
}
