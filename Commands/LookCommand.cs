using RogueSheep;

namespace BurglarOfBabylon.Commands
{
    public sealed class LookCommand : Command
    {
        public Point2i Position { get; }
        public LookCommand(Actor? originator, Point2i position) : base(originator)
        {
            Position = position;
        }
    }
}
