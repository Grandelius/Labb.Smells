using Labb.Smells.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Labb.Smells.Classes
{
    public class PlayerData
    {

        IPlayer player;

        private static PlayerData? instance;

        private PlayerData() { }

        public static PlayerData Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new PlayerData();
                }
                return instance;
            }
        }



        public List<IPlayer> GetPlayerData()
        {
            StreamReader resultLog = new StreamReader("result.txt");

            List<IPlayer> playerList = SortPlayerData(resultLog);

            resultLog.Close();

            return playerList;
        }

        private List<IPlayer> SortPlayerData(StreamReader playerData)
        {
            List<IPlayer> results = new List<IPlayer>();
            string line;
            while ((line = playerData.ReadLine()) != null)
            {
                string[] nameAndScore = line.Split(new string[] { "#&#" }, StringSplitOptions.None);
                string name = nameAndScore[0];
                int guesses = Convert.ToInt32(nameAndScore[1]);
                IPlayer player = new Player(name, guesses);
                int pos = results.IndexOf(player);
                if (pos < 0)
                {
                    results.Add(player);
                }
                else
                {
                    results[pos].Update(guesses);
                }
            }

            return results;
        }

        public List<IPlayer> SortHighscoreList(List<IPlayer> playerList)
        {
            playerList.Sort((p1, p2) => p1.Average().CompareTo(p2.Average()));

            return playerList;
        }

        public void SavePlayerData(string name, int guessCount)
        {
            StreamWriter result = new StreamWriter("result.txt", append: true);
            result.WriteLine(name + "#&#" + guessCount);
            result.Close();
        }
    }
}
