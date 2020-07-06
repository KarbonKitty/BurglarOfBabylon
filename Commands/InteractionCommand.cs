using RogueSheep;

namespace BurglarOfBabylon.Commands
{
    public class InteractionCommand : Command
    {
        public Point2i Target { get; }

        public InteractionCommand(Actor originator, Point2i target) : base(originator)
        {
            Target = target;
        }
    }
}
