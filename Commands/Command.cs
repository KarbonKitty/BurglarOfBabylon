namespace BurglarOfBabylon.Commands
{
    public abstract class Command
    {
        public MapEntity? Originator { get; }

        protected Command(MapEntity? originator)
        {
            Originator = originator;
        }
    }
}
