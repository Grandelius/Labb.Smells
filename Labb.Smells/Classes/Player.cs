using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Labb.Smells.Interfaces;

namespace Labb.Smells.Classes
{
    public class Player : IPlayer
    {
        IUI io;
        public string Name { get; set; }
        public string Guess { get; set; }
        public int NumberOfGames { get; set; }
        public int TotalGuess { get; set; }

        public Player(string name, int guesses)
        {
            this.Name = name;
            NumberOfGames = 1;
            this.TotalGuess = guesses;
        }

        public void Update(int guesses)
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
