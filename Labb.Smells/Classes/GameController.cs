using Labb.Smells.Classes;
using Labb.Smells.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb.Smells.Classes
{
    public class GameController
    {
        private readonly IUI io;
        private readonly PlayerData playerData;

        IPlayer player;

        public GameController()
        {
            this.io = new TextIO();
            this.playerData = PlayerData.Instance;
        }

        public void Run()
        {
            string playerName = CreateUserName();

            NewGame(playerName);

        }

        private string CreateUserName()
        {
            io.Print("Enter your user name:\n");
            string playerName = io.GetInput();

            return playerName;
        }

        private void NewGame(string playerName)
        {
            bool playOn = true;

            player = new Player(playerName, 0);

            while (playOn)
            {
                string correctNumbers = CreateTargetNumber();

                player.TotalGuess = 0;

                player = Guessing(correctNumbers, player);

                playerData.SavePlayerData(player.Name, player.TotalGuess);

                ShowTopList();

                PrintFinalResult(player.TotalGuess);

                playOn = KeepPlaying();
            }
        }


        private string CreateTargetNumber()
        {

            Random randomGenerator = new Random();
            List<int> availableDigits = new List<int>(10); // List to track available digits
            for (int i = 0; i < 10; i++)
            {
                availableDigits.Add(i); // Initialize the list with all digits
            }

            string target = "";
            for (int i = 0; i < 4; i++)
            {
                int randomIndex = randomGenerator.Next(availableDigits.Count);
                int randomDigit = availableDigits[randomIndex]; // Get a random available digit
                availableDigits.RemoveAt(randomIndex); // Remove the used digit

                target += randomDigit.ToString();
            }

            return target;
        }

        private string PrintGuessResult(string target, string guess)
        {
            try
            {
            const string correctPlaceSymbol = "B";
            const string correctNumberSymbol = "C";

            int correctPlaceCount = 0;
            int correctNumberCount = 0;

                guess += new string(' ', 4 - guess.Length); 
  

            for (int i = 0; i < 4; i++)
            {
                if (target[i] == guess[i])
                {
                    correctPlaceCount++;
                }
                else if (target.Contains(guess[i]))
                {
                    correctNumberCount++;
                }
            }

            string result = string.Concat(Enumerable.Repeat(correctPlaceSymbol, correctPlaceCount))
                            + "," +
                            string.Concat(Enumerable.Repeat(correctNumberSymbol, correctNumberCount));

            return result;
            }
            catch
            {
                return "Incorrect number of digits, try again!";
            }
        }

        private IPlayer Guessing(string correctNumbers, IPlayer player)
        {
            io.Print("New game:\n");

            //comment out or remove next line to play real games!
            io.Print("For practice, number is: " + correctNumbers + "\n");

            while (true)
            {
                player.TotalGuess++;
                player.Guess = io.GetInput();
                io.Print(player.Guess + "\n");

                string guessResult = PrintGuessResult(correctNumbers, player.Guess);
                io.Print(guessResult + "\n");

                if (guessResult == "BBBB,")
                {
                    break;
                }
            }

            return player;
        }

        private void PrintFinalResult(int guessCount)
        {
            io.Print("Correct, it took " + guessCount + " guesses\nContinue?");
        }

        private bool KeepPlaying()
        {
            bool keepPlaying = true;

            io.Print("Do you want to keep playing?");
            string answer = io.GetInput();
            if (answer != null && answer != "" && answer.Substring(0, 1) == "n")
            {
                keepPlaying = false;
            }

            return keepPlaying;
        }

        public List<IPlayer> GetSortedTopList()
        {
            List<IPlayer> players = playerData.GetPlayerData();

            players = playerData.SortHighscoreList(players);

            return players;
            
        }

        public void ShowTopList()
        {
            List<IPlayer> players = GetSortedTopList();

            io.Print("Player   games average");
            foreach (IPlayer p in players)
            {
                io.Print(string.Format("{0,-9}{1,5:D}{2,9:F2}", p.Name, p.NumberOfGames, p.Average()));
            }

        }
    }
}
