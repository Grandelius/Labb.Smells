using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Labb.Smells.Interfaces
{
    public interface IRandomNumberGenerator
    {
       int Next(int minValue, int maxValue);
    }
}
