namespace Labb.Smells.Interfaces
{
    public interface IPlayerData
    {
        List<IPlayer> GetPlayerData();
        void SavePlayerData(string name, int guessCount);
        List<IPlayer> SortHighscoreList(List<IPlayer> playerList);
    }
}