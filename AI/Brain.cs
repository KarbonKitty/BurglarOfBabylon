using BurglarOfBabylon.Commands;

namespace BurglarOfBabylon.AI
{
    public abstract class ActorBrain
    {
        public abstract Command Act(Actor me, GameState gameState);
    }
}
