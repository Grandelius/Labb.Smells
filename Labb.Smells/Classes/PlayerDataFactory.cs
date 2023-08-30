using Labb.Smells.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb.Smells.Classes
{
    public class PlayerDataFactory
    {
        public static IPlayerData CreateMooGamePlayerData()
        {
            return new PlayerData("MooGameResult.txt");
        }

        public static IPlayerData CreateMastermindPlayerData()
        {
            return new PlayerData("MastermindResult.txt");
        }

    }
}
