namespace BurglarOfBabylon.Conditions
{
    public abstract class Condition
    {
        public abstract void TimePasses();

        public int TimeLeft { get; protected set; }
    }
}
