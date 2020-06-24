namespace BurglarOfBabylon.Commands
{
    public abstract class Command
    {
        public Actor? Originator { get; }

        protected Command(Actor? originator)
        {
            Originator = originator;
        }
    }
}
