using BurglarOfBabylon.Commands;
using RogueSheep;
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

        public virtual void Use(Actor user, GameState state, Direction? direction = null)
        {
            var used = false;
            if (Template.Usage != null)
            {
                Template.Usage!(user, state);
                used = true;
            }

            if (Template.DirectionalUsage != null && direction.HasValue)
            {
                Template.DirectionalUsage(user, direction.Value, state);
                used = true;
            }

            if (used && Template.MaxUses != null)
            {
                UsesLeft--;
                if (UsesLeft == 0)
                {
                    CommandProcessor.ProcessCommand(new ItemUsedUpCommand(user, this), state);
                }
            }
        }

        public bool CanBeUsed() => Template.Usage != null || Template.DirectionalUsage != null;

        public bool IsDirectional() => Template.DirectionalUsage != null;
    }
}
