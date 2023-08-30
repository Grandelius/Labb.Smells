using Labb.Smells.Interfaces;

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
