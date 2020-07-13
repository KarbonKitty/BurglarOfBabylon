using RogueSheep;
using RogueSheep.Display;

namespace BurglarOfBabylon
{
    public static class ItemDefinitions
    {
        public static Item Watch = new Item("watch", new GameTile(CP437Glyph.LargeDot), (a, gs) => gs.Messages.Push(gs.CurrentTime.ToString("F")));
        public static Item SignalJammer = new Item("signal jammer", new GameTile(CP437Glyph.Percent), (a, gs) => { if (gs.AlertLevel > 0) gs.AlertLevel--; });
    }
}
