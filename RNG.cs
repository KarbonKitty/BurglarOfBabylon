using RogueSheep.RandomNumbers;

namespace BurglarOfBabylon
{
        public static class RNG
    {
        private static readonly MultistreamPCGRandom rng;

        static RNG()
        {
            rng = new MultistreamPCGRandom(42);
        }

        public static IRandom GetGenerator(uint stream) => rng[stream];

        public static int Next() => rng[1].Next();

        public static int Next(int maxValue) => rng[1].Next(maxValue);

        public static int Next(int minValue, int maxValue) => rng[1].Next(minValue, maxValue);
    }
}
