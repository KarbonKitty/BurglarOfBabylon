using BurglarOfBabylon.Items;
using RogueSheep;

namespace BurglarOfBabylon.Commands
{
    public sealed class UseCommand : Command
    {
        public Item Item { get; }
        public Direction? Direction { get; }

        public UseCommand(Actor originator, Item item, Direction? direction = null) : base(originator)
        {
            Item = item;
            Direction = direction;
        }
    }
}
