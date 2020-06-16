using RogueSheep;

namespace BurglarOfBabylon
{
    public class GameState
    {
        public MapEntity Player { get; set; }

        public GameState()
        {
            Player = new MapEntity((4, 4), new MapTile(CP437Glyph.AtSign, RogueColor.Lime));
        }
    }
}
