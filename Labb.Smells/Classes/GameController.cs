using Labb.Smells.Interfaces;
using System.Text.RegularExpressions;

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

        public bool Run()
        {
            string playerName = CreateUserName();

            StartGame(playerName);

            return false;
        }

        internal string CreateUserName()
        {
            io.Print("Enter your user name:");
            string playerName = io.GetInput();

            return playerName;
        }

        private void StartGame(string playerName) 
        {
            bool play = true;

            player = new Player(playerName, 0);

            while (play)
            {
                string target = randomNumberGenerator.CreateTargetNumbers();

                player = NewGuessingGame(target, player);

                playerData.SavePlayerData(player.Name, player.TotalGuess);

                ShowTopList();

                PrintFinalResult(player.TotalGuess);

                play = KeepPlaying();
            }
        }

        internal string PrintGuessResult(string target, string guess)
        {
            if (!ValidGuess(guess))
            {
                return "Invalid input!\nType 4 digits only: ";
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

        internal IPlayer NewGuessingGame(string targetNumbers, IPlayer player)
        {
            player.TotalGuess = 0; // Resets guesses when starting new game

            io.Print("New game, enter 4 digits: " + targetNumbers);

            while (true)
            {
                string correctResult = "BBBB,";

                player.TotalGuess++;
                player.Guess = io.GetInput();
                io.Print(player.Guess);

                string guessResult = PrintGuessResult(targetNumbers, player.Guess);
                io.Print(guessResult);

                if (guessResult == correctResult)
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

        internal bool KeepPlaying()
        {
            bool keepPlaying = true;

            string stopPlaying = "n";

            io.Print("Do you want to keep playing? (y/n)");
            string answer = io.GetInput();
            if (answer != null && answer != "" && answer.Substring(0, 1) == stopPlaying)
            {
                keepPlaying = false;
            }

            return keepPlaying;
        }

        private List<IPlayer> GetSortedTopList()
        {

            List<IPlayer> players = playerData.GetPlayerData();

            return players;

        }

        private void ShowTopList()
        {
            List<IPlayer> players = GetSortedTopList();

            if (players.Count != 0)
            {
                io.Print("Player   games average");
                foreach (IPlayer p in players)
                {
                    io.Print(string.Format("{0,-9}{1,5:D}{2,9:F2}", p.Name, p.NumberOfGames, p.Average()));
                }
            }
            else
            {
                io.Print("Erroo loading highscoredata");
            }
        }

        internal bool ValidGuess(string guess)
        {
            var regex = new Regex("^[0-9]{4}$");
            bool isValid = regex.IsMatch(guess);

            return isValid;
        }
    }

}
