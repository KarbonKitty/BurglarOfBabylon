using BurglarOfBabylon.Items;

namespace BurglarOfBabylon.Commands
{
    public sealed class UseCommand : Command
    {
        public Item Item { get; }

        public UseCommand(Actor originator, Item item) : base(originator)
        {
            Item = item;
        }
    }
}
