using BurglarOfBabylon.Commands;
using RogueSheep;

namespace BurglarOfBabylon.AI
{
    public class PatrolBrain : ActorBrain
    {
        private readonly Point2i start;
        private readonly Point2i end;
        private bool startToEnd;

        public PatrolBrain(Point2i start, Point2i end)
        {
            this.start = start;
            this.end = end;
            this.startToEnd = true;
        }

        public override Command Act(Actor me, GameState gameState)
        {
            var bfs = new BreadthFirstSearch(gameState.CurrentMap.GetPassabilityGrid());
            var path = bfs.GetPath(me.Position, startToEnd ? end : start);
            if (path.Count == 0)
            {
                startToEnd = !startToEnd;
                return new WaitCommand(me);
            }
            return new MoveCommand(me, (path[0] - me.Position).DirectionFromVector());
        }
    }
}
