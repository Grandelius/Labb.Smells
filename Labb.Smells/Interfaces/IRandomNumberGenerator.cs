

namespace Labb.Smells.Interfaces
{
    
    public interface IRandomNumberGenerator
    {
        string CreateTargetNumbers();

        int Next(int minValue, int maxValue);
    }
}
