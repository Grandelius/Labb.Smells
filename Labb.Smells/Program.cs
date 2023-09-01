using Labb.Smells.Classes;
using Labb.Smells.Interfaces;

IUI io = new TextIO();

IPlayerData mooGameplayerData = PlayerDataFactory.CreateMooGamePlayerData();
IRandomNumberGenerator mooGameRandomNumberGenerator = RandomNumberGeneratorFactory.CreateMooGameNumberGenerator();

IPlayerData mastermindPlayerData = PlayerDataFactory.CreateMastermindPlayerData();
IRandomNumberGenerator mastermindRandomNumberGenerator = RandomNumberGeneratorFactory.CreateMastermindNumberGenerator();

bool runMenu = true;

while (runMenu)
{
    io.PrintStartMenu();

    string result = io.GetInput();

    switch (result)
    {
        case "1":
            io.Print("You have chosen MooGame!");
            GameController mooGameController = new GameController(io, mooGameplayerData, mooGameRandomNumberGenerator);
            runMenu = mooGameController.Run();
            break;

        case "2":
            io.Print("You have chosen Mastermind");
            GameController mastermindController = new GameController(io, mastermindPlayerData, mastermindRandomNumberGenerator);
            runMenu = mastermindController.Run();
            break;

        default:
            io.Print("Incorrect input, try again!");
            break;
    }
}










