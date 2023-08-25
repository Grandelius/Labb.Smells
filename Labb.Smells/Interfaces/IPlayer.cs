namespace Labb.Smells.Interfaces
{
    internal interface IPlayer
    {
        string Name { get; }
        int NumberOfGames { get; }


        double Average();
        bool Equals(object p);
        int GetHashCode();
        void Update(int guesses);
    }
}