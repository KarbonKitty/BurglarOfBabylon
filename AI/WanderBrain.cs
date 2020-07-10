using BurglarOfBabylon.Commands;
using RogueSheep;

namespace BurglarOfBabylon.AI
{
    public class WanderBrain : ActorBrain
    {
        public override Command Act(Actor me, GameState gameState)
        {
            var direction = (Direction)(RNG.Next(8) + 1);
            return new MoveCommand(me, direction);
        }
    }
}
