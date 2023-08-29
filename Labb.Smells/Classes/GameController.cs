using Labb.Smells.Classes;
using Labb.Smells.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
namespace Labb.Smells.Classes
{
    public class GameController
    {
        public IUI io;
        private readonly IPlayerData playerData;
        private readonly IRandomNumberGenerator randomNumberGenerator;

        private IPlayer player;

        public GameController(IUI io, IPlayerData playerData, IRandomNumberGenerator randomNumberGenerator)
        {
            this.io = io;
            this.playerData = playerData;
            this.randomNumberGenerator = randomNumberGenerator;

        }

        public void Run()
        {
            string playerName = CreateUserName();

            StartGame(playerName);

        }

        public string CreateUserName()
        {
            io.Print("Enter your user name:");
            string playerName = io.GetInput();

            return playerName;
        }

        private void StartGame(string playerName)
        {
            bool playOn = true;

            player = new Player(playerName, 0);

            while (playOn)
            {
                string targetNumbers = CreateTargetNumber();


                player = NewGuessingGame(targetNumbers, player);

                playerData.SavePlayerData(player.Name, player.TotalGuess);

                ShowTopList();

                PrintFinalResult(player.TotalGuess);

                playOn = KeepPlaying();
            }
        }


        public string CreateTargetNumber()
        {

            List<int> availableDigits = new List<int>(10); // List to track available digits
            for (int i = 0; i < 10; i++)
            {
                availableDigits.Add(i); // Initialize the list with all digits
            }

            string target = "";
            for (int i = 0; i < 4; i++)
            {
                int randomIndex = randomNumberGenerator.Next(0,availableDigits.Count);
                int randomDigit = availableDigits[randomIndex]; // Get a random available digit
                availableDigits.RemoveAt(randomIndex); // Remove the used digit

                target += randomDigit.ToString();
            }

            return target;
        }

        public string PrintGuessResult(string target, string guess)
        {
            if (!ValidGuess(guess))
            {
                return "Invalid input!\nType 4 digits only:";
            }

            const string correctPlaceSymbol = "B";
            const string targetNumbersymbol = "C";

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
                            string.Concat(Enumerable.Repeat(targetNumbersymbol, correctNumberCount));

            return result;


        }

        private IPlayer NewGuessingGame(string targetNumbers, IPlayer player)
        {
            player.TotalGuess = 0; // Reset guesses when starting new game

            io.Print("New game:");

            //comment out or remove next line to play real games!
            io.Print("For practice, number is: " + targetNumbers);

            while (true)
            {
                player.TotalGuess++;
                player.Guess = io.GetInput();
                io.Print(player.Guess);

                string guessResult = PrintGuessResult(targetNumbers, player.Guess);
                io.Print(guessResult);

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

        public bool KeepPlaying()
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
        public bool ValidGuess(string guess)
        {
            var regex = new Regex("^[0-9]{4}$");
            bool isValid = regex.IsMatch(guess);

            return isValid;
        }
    }

}
