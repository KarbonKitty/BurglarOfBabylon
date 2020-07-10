using System;
using RogueSheep;

namespace BurglarOfBabylon.Commands
{
    public sealed class MoveCommand : Command
    {
        public Direction Direction { get; }

        public MoveCommand(Actor originator, Direction direction) : base(originator)
        {
            if (originator is null)
            {
                throw new ArgumentNullException(nameof(originator), "Originator of the move command cannot be null");
            }
            Direction = direction;
        }
    }
}
