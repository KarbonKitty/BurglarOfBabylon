using System;
using RogueSheep;

namespace BurglarOfBabylon.Commands
{
    public sealed class MoveCommand : Command
    {
        public Point2i Vector { get; }

        public MoveCommand(Actor originator, Point2i vector) : base(originator)
        {
            if (originator is null)
            {
                throw new ArgumentNullException(nameof(originator), "Originator of the move command cannot be null");
            }
            Vector = vector;
        }
    }
}
