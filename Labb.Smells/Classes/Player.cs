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

        public string Name { get; private set; }

        public string guess;
        public int NumberOfGames { get; private set; }

        public int totalGuess;


        public Player(string name, int guesses)
        {
            this.Name = name;
            NumberOfGames = 1;
            totalGuess = guesses;
        }

        public void Update(int guesses)
        {
            totalGuess += guesses;
            NumberOfGames++;
        }

        public double Average()
        {
            return (double)totalGuess / NumberOfGames;
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
