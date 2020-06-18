namespace BurglarOfBabylon.Commands
{
    public sealed class NullCommand : Command
    {
        public NullCommand() : base(originator: null) {}
    }
}
