#Guessing Game Application!

##Welcome to the Guessing Game Application! This application allows players to play a number guessing game and compete for the lowest average number of guesses. The game features a user-friendly console interface and maintains a highscore list of players.

Features
Modular Design: The application has been refactored to follow a modular design, making it easier to understand, maintain, and extend.
MVC Pattern: The application follows the Model-View-Controller (MVC) architectural pattern, separating concerns and promoting a clear separation between user interface, player data, and game logic.
Singleton Pattern: The PlayerData class has been implemented as a singleton, ensuring a single instance of the class is used throughout the application.
Interfaces: Interfaces such as IPlayer and IUI define contracts that provide consistency, flexibility, and promote code reuse.
Clean Code: The codebase has been improved for readability, maintainability, and adherence to coding standards.
How to Play
Clone the repository to your local machine.
Build and run the application using your preferred development environment.
Follow the on-screen prompts to create a user name and start playing the game.
Guess the correct number and try to achieve the lowest average number of guesses.
The application will display a highscore list of players based on their average number of guesses.
Structure
The application is structured into three main components:

TextIO: This class handles user input and output using the console, providing a user-friendly interface for playing the game.
PlayerData: The PlayerData class manages player information, including loading player data from a file, sorting highscores, and saving player results.
GameController: The GameController class orchestrates the game flow, player interactions, and displays highscore information.


Original Code: 

	class MainClass
	{

		public static void Main(string[] args)
		{

			bool playOn = true;
			Console.WriteLine("Enter your user name:\n");
			string name = Console.ReadLine();

			while (playOn)
			{
				string goal = makeGoal();

				
				Console.WriteLine("New game:\n");
				//comment out or remove next line to play real games!
				Console.WriteLine("For practice, number is: " + goal + "\n");
				string guess = Console.ReadLine();
				
				int nGuess = 1;
				string bbcc = checkBC(goal, guess);
				Console.WriteLine(bbcc + "\n");
				while (bbcc != "BBBB,")
				{
					nGuess++;
					guess = Console.ReadLine();
					Console.WriteLine(guess + "\n");
					bbcc = checkBC(goal, guess);
					Console.WriteLine(bbcc + "\n");
				}
				StreamWriter output = new StreamWriter("result.txt", append: true);
				output.WriteLine(name + "#&#" + nGuess);
				output.Close();
				showTopList();
				Console.WriteLine("Correct, it took " + nGuess + " guesses\nContinue?");
				string answer = Console.ReadLine();
				if (answer != null && answer != "" && answer.Substring(0, 1) == "n")
				{
					playOn = false;
				}
			}
		}
		static string makeGoal()
		{
			Random randomGenerator = new Random();
			string goal = "";
			for (int i = 0; i < 4; i++)
			{
				int random = randomGenerator.Next(10);
				string randomDigit = "" + random;
				while (goal.Contains(randomDigit))
				{
					random = randomGenerator.Next(10);
					randomDigit = "" + random;
				}
				goal = goal + randomDigit;
			}
			return goal;
		}

		static string checkBC(string goal, string guess)
		{
			int cows = 0, bulls = 0;
			guess += "    ";     // if player entered less than 4 chars
			for (int i = 0; i < 4; i++)
			{
				for (int j = 0; j < 4; j++)
				{
					if (goal[i] == guess[j])
					{
						if (i == j)
						{
							bulls++;
						}
						else
						{
							cows++;
						}
					}
				}
			}
			return "BBBB".Substring(0, bulls) + "," + "CCCC".Substring(0, cows);
		}


		static void showTopList()
		{
			StreamReader input = new StreamReader("result.txt");
			List<PlayerData> results = new List<PlayerData>();
			string line;
			while ((line = input.ReadLine()) != null)
			{
				string[] nameAndScore = line.Split(new string[] { "#&#" }, StringSplitOptions.None);
				string name = nameAndScore[0];
				int guesses = Convert.ToInt32(nameAndScore[1]);
				PlayerData pd = new PlayerData(name, guesses);
				int pos = results.IndexOf(pd);
				if (pos < 0)
				{
					results.Add(pd);
				}
				else
				{
					results[pos].Update(guesses);
				}
				
				
			}
			results.Sort((p1, p2) => p1.Average().CompareTo(p2.Average()));
			Console.WriteLine("Player   games average");
			foreach (PlayerData p in results)
			{
				Console.WriteLine(string.Format("{0,-9}{1,5:D}{2,9:F2}", p.Name, p.NGames, p.Average()));
			}
			input.Close();
		}
	}

	class PlayerData
	{
		public string Name { get; private set; }
        public int NGames { get; private set; }
		int totalGuess;
		

		public PlayerData(string name, int guesses)
		{
			this.Name = name;
			NGames = 1;
			totalGuess = guesses;
		}

		public void Update(int guesses)
		{
			totalGuess += guesses;
			NGames++;
		}

		public double Average()
		{
			return (double)totalGuess / NGames;
		}

		
	    public override bool Equals(Object p)
		{
			return Name.Equals(((PlayerData)p).Name);
		}

		
	    public override int GetHashCode()
        {
			return Name.GetHashCode();
		}
	}
}
