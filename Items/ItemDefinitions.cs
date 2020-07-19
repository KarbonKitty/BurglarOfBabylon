using RogueSheep;
using RogueSheep.Display;

namespace BurglarOfBabylon.Items
{
    public static class ItemDefinitions
    {
        public static Item Watch = new Item("watch", new GameTile(CP437Glyph.LargeDot), (a, gs) => gs.Messages.Push(gs.CurrentTime.ToString("F")));
        public static Item SignalJammer = new LimitedUseItem("signal jammer", new GameTile(CP437Glyph.Percent, new RogueColor(9 * 16, 9 * 16, 255)), (a, gs) => { if (gs.AlertLevel > 0) gs.AlertLevel--; }, 1);
    }
}
