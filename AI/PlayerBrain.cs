using BurglarOfBabylon.Commands;

namespace BurglarOfBabylon.AI
{
    public sealed class PlayerBrain : ActorBrain
    {
        public Command? StoredCommand { get; set; }

        public override Command Act(Actor me, GameState gameState)
        {
            if (StoredCommand is null)
            {
                return new NullCommand();
            }
            else
            {
                var command = StoredCommand;
                StoredCommand = null;
                return command;
            }
        }
    }
}
