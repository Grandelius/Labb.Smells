using Labb.Smells.Interfaces;

namespace Labb.Smells.Classes
{
    public class RandomNumberGenerator : IRandomNumberGenerator
    {
        private Random random;
        public int MinValue { get; }
        public int MaxValue { get; }

        public RandomNumberGenerator(int minValue, int maxValue)
        {
            random = new Random();
            MinValue = minValue;
            MaxValue = maxValue;

        }

        public string CreateTargetNumbers()
        {
            List<int> availableDigits = new List<int>(MaxValue); // List to track available digits

            for (int i = 0; i < MaxValue; i++)
            {
                availableDigits.Add(i); // Initialize the list with all digits
            }

            string target = "";
            for (int i = 0; i < 4; i++)
            {
                int randomIndex = random.Next(0, availableDigits.Count);
                int randomDigit = availableDigits[randomIndex]; // Get a random available digit
                availableDigits.RemoveAt(randomIndex); // Remove the used digit

                target += randomDigit.ToString();
            }

            return target;
        }

        public int Next(int minValue, int maxValue)
        {
            return random.Next(minValue, maxValue);
        }
    }
}

