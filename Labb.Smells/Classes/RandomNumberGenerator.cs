using Labb.Smells.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb.Smells.Classes
{
    public class RandomNumberGenerator : IRandomNumberGenerator
    {
        private Random random = new Random();

        public int Next(int minValue, int maxValue)
        {
            return random.Next(minValue, maxValue);
        }
    }
}
