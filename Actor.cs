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
        public ActorBrain Brain { get; }

        public Actor(string name, Point2i position, GameTile presentation, ActorBrain brain)
        {
            Name = name;
            Position = position;
            Presentation = presentation;
            Brain = brain;
        }

        public bool Move(Point2i vector)
        {
            Position += vector;
            return true;
        }

        public Command Act(GameState gameState) => Brain.Act(this, gameState);
    }
}
