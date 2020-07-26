using BurglarOfBabylon.Commands;
using RogueSheep.Display;

namespace BurglarOfBabylon.Items
{
    public class Item : IPresentable
    {
        public virtual ItemDefinition Template { get; }

        public GameTile Presentation => Template.Presentation;

        public int? UsesLeft { get; private set; }

        public Item(ItemDefinition template)
        {
            Template = template;
        }

        public virtual void Use(Actor user, GameState state)
        {
            if (CanBeUsed())
            {
                Template.Usage!(user, state);
                if (Template.MaxUses != null)
                {
                    UsesLeft--;
                    if (UsesLeft == 0)
                    {
                        CommandProcessor.ProcessCommand(new ItemUsedUpCommand(user, this), state);
                    }
                }
            }
        }

        public bool CanBeUsed() => Template.Usage != null;
    }
}
