using BurglarOfBabylon.AI;
using BurglarOfBabylon.Commands;
using RogueSheep;
using RogueSheep.Display;
using RogueSheep.Maps;

namespace BurglarOfBabylon
{
    public class Actor : IHasPosition, IPresentable
    {
        public string Name { get; }
        public Point2i Position { get; private set; }
        public GameTile Presentation { get; }
        public Direction Direction { get; private set; }
        public ActorBrain Brain { get; }
        public ActorRole Role { get; }

        public Actor(string name, Point2i position, GameTile presentation, Direction direction, ActorBrain brain, ActorRole role)
        {
            Name = name;
            Position = position;
            Presentation = presentation;
            Direction = direction;
            Brain = brain;
            Role = role;
        }

        public bool Move(Direction direction)
        {
            Position += direction.Vector();
            Direction = direction;
            return true;
        }

        public Command Act(GameState gameState) => Brain.Act(this, gameState);
    }
}
