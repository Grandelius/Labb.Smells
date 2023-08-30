using Labb.Smells.Classes;
using Labb.Smells.Interfaces;

IUI io = new TextIO();

IPlayerData mooGameplayerData = PlayerDataFactory.CreateMooGamePlayerData();
IRandomNumberGenerator mooGameRandomNumberGenerator = RandomNumberGeneratorFactory.CreateMooGameNumberGenerator();

IPlayerData mastermindPlayerData = PlayerDataFactory.CreateMastermindPlayerData();
IRandomNumberGenerator mastermindRandomNumberGenerator = RandomNumberGeneratorFactory.CreateMastermindNumberGenerator();

string mooGame = "1";
string mastermind = "2";

io.PrintStartMenu();

string result = io.GetInput();

if (result == mooGame)
{
    io.Print("You choosed MooGame!");
    GameController gameController = new GameController(io, mooGameplayerData, mooGameRandomNumberGenerator);
    gameController.Run();
}

if (result == mastermind)
{
    io.Print("You choosed Mastermind");
    GameController gameController = new GameController(io, mastermindPlayerData, mastermindRandomNumberGenerator);
    gameController.Run();
}






