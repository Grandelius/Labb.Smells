namespace Labb.Smells.Interfaces
{
    public interface IPlayer
    {
       public string Name { get; set; }

       public string Guess { get; set; }
       public int NumberOfGames { get; set; }

       public int TotalGuess { get; set;  }


        double Average();
        bool Equals(object p);
        int GetHashCode();
        void AddGuesses(int guesses);
    }
}