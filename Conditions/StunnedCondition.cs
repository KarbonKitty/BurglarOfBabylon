namespace BurglarOfBabylon.Conditions
{
    public sealed class StunnedCondition : Condition
    {
        public StunnedCondition(int duration)
        {
            TimeLeft = duration;
        }

        public override void TimePasses()
        {
            TimeLeft--;
        }
    }
}
