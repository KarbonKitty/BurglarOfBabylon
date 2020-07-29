using System.Linq;
using BurglarOfBabylon.Conditions;
using RogueSheep;
using RogueSheep.Display;

namespace BurglarOfBabylon.Items
{
    public static class ItemDefinitions
    {
        public static ItemDefinition Watch = new ItemDefinition("watch", new GameTile(CP437Glyph.LargeDot), (a, gs) => gs.Messages.Push(gs.CurrentTime.ToString("F")));
        public static ItemDefinition SignalJammer = new ItemDefinition("signal jammer", new GameTile(CP437Glyph.Percent, new RogueColor(9 * 16, 9 * 16, 255)), (a, gs) => { if (gs.AlertLevel > 0) gs.AlertLevel--; }, 1);
        public static ItemDefinition Keycard = new ItemDefinition("keycard", new GameTile(CP437Glyph.Diamond, RogueColor.Red), (a, gs) => gs.Messages.Push("When you try to open the door, the keycard will be used automatically."));

        public static ItemDefinition StolenData = new ItemDefinition("*STOLEN DATA*", new GameTile(CP437Glyph.Dollar, RogueColor.BlueViolet), (a, gs) => gs.Messages.Push("Just get out of here with it!"));

        public static ItemDefinition StunGun = new ItemDefinition("stun gun", new GameTile(CP437Glyph.ExclamationMark, RogueColor.LightBlue), directionalUse: (a, d, gs) => {
            var target = gs.CurrentMap.Actors.SingleOrDefault(t => t.Position == a.Position.Transform(d));
            if (target != null)
            {
                target.Conditions.Add(new StunnedCondition(3));
                gs.Messages.Push($"{target.Name} was stunned!");
            }
            else
            {
                gs.Messages.Push("Nobody to stun there!");
            }
        });
    }
}
