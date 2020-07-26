using RogueSheep;

namespace BurglarOfBabylon.Commands
{
    public sealed class TalkCommand : Command
    {
        public Point2i TargetPosition { get; set; }

        public TalkCommand(Actor? originator, Point2i targetPosition) : base(originator)
        {
            TargetPosition = targetPosition;
        }
    }
}
