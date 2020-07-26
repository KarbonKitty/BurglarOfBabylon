using RogueSheep;
using RogueSheep.Display;

namespace BurglarOfBabylon.Items
{
    public static class ItemDefinitions
    {
        public static ItemDefinition Watch = new ItemDefinition("watch", new GameTile(CP437Glyph.LargeDot), (a, gs) => gs.Messages.Push(gs.CurrentTime.ToString("F")));
        public static ItemDefinition SignalJammer = new ItemDefinition("signal jammer", new GameTile(CP437Glyph.Percent, new RogueColor(9 * 16, 9 * 16, 255)), (a, gs) => { if (gs.AlertLevel > 0) gs.AlertLevel--; }, 1);
        public static ItemDefinition Keycard = new ItemDefinition("keycard", new GameTile(CP437Glyph.Diamond, RogueColor.Red), (a, gs) => gs.Messages.Push("When you try to open the door, the keycard will be used automatically."));
    }
}
