using System;
using System.IO;
using System.Collections.Generic;
using Labb.Smells.Classes;
using Labb.Smells.Interfaces;

IUI io = new TextIO();
IPlayerData playerData = PlayerData.Instance;
IRandomNumberGenerator randomNumberGenerator = new RandomNumberGenerator();

GameController gameController = new GameController(io, playerData, randomNumberGenerator);

gameController.Run();

