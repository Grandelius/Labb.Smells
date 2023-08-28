using System;
using System.IO;
using System.Collections.Generic;
using Labb.Smells.Classes;
using Labb.Smells.Interfaces;

IUI io = new TextIO();
IPlayerData playerData = PlayerData.Instance;

GameController gameController = new GameController(io, playerData);

gameController.Run();
