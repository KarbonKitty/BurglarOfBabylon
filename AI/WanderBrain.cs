using BurglarOfBabylon.Commands;

namespace BurglarOfBabylon.AI
{
    public class WanderBrain : ActorBrain
    {
        public override Command Act(Actor me, GameState gameState)
        {
            var direction = (RNG.Next(3) - 1, RNG.Next(3) - 1);
            return new MoveCommand(me, direction);
        }
    }
}
