using RogueSheep;

namespace BurglarOfBabylon.Commands
{
    public class InteractionCommand : Command
    {
        public Direction TargetDirection { get; }

        public InteractionCommand(Actor originator, Direction targetDirection) : base(originator)
        {
            TargetDirection = targetDirection;
        }
    }
}
