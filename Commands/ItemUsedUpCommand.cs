using BurglarOfBabylon.Items;

namespace BurglarOfBabylon.Commands
{
    public sealed class ItemUsedUpCommand : Command
    {
        public Item ItemUsedUp { get; }

        public ItemUsedUpCommand(Actor? originator, Item itemUsedUp) : base(originator)
        {
            ItemUsedUp = itemUsedUp;
        }
    }
}
