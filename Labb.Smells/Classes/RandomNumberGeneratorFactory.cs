using Labb.Smells.Interfaces;

namespace Labb.Smells.Classes
{
    public static class RandomNumberGeneratorFactory
    {
        public static IRandomNumberGenerator CreateMooGameNumberGenerator()
        {
            return new RandomNumberGenerator(0, 10);
        }

        public static IRandomNumberGenerator CreateMastermindNumberGenerator()
        {
            return new RandomNumberGenerator(0, 7);
        }
    }
}
