using System;
using System.IO;
using System.Collections.Generic;
using Labb.Smells.Classes;
using Labb.Smells.Interfaces;

IUI io = new TextIO();

IPlayerData mooGameplayerData = PlayerDataFactory.CreateMooGamePlayerData();
IRandomNumberGenerator mooGameRandomNumberGenerator = RandomNumberGeneratorFactory.CreateMooGameNumberGenerator();

IPlayerData mastermindPlayerData = PlayerDataFactory.CreateMastermindPlayerData();
IRandomNumberGenerator mastermindRandomNumberGenerator = RandomNumberGeneratorFactory.CreateMastermindNumberGenerator();

io.PrintStartMenu();

string result = io.GetInput();

if (result == "1")
{
    GameController gameController = new GameController(io, mooGameplayerData, mooGameRandomNumberGenerator);
    gameController.Run();
}

if (result == "2")
{
    GameController gameController = new GameController(io, mastermindPlayerData, mastermindRandomNumberGenerator);
    gameController.Run();
}






