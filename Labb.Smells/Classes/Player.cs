using Labb.Smells.Interfaces;

namespace Labb.Smells.Classes
{
    public class Player : IPlayer
    {
        public string Name { get; set; }
        public string Guess { get; set; }
        public int NumberOfGames { get; set; }
        public int TotalGuess { get; set; }

        public Player(string name, int guesses)
        {
            this.Name = name;
            this.TotalGuess = guesses;
            NumberOfGames = 1;
        }

        public void AddNewResult(int guesses)
        {
            TotalGuess += guesses;
            NumberOfGames++;
        }

        public double Average()
        {
            return (double)TotalGuess / NumberOfGames;
        }


        public override bool Equals(Object player)
        {
            return Name.Equals(((Player)player).Name);
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
    }
}
