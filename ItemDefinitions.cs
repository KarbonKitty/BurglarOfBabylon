using RogueSheep;
using RogueSheep.Display;

namespace BurglarOfBabylon
{
    public static class ItemDefinitions
    {
        public static Item SignalJammer = new Item("signal jammer", new GameTile(CP437Glyph.Percent), (a, gs) => { if (gs.AlertLevel > 0) gs.AlertLevel--; });
    }
}
