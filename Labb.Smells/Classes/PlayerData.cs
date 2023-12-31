﻿using Labb.Smells.Interfaces;


namespace Labb.Smells.Classes
{
    public class PlayerData : IPlayerData
    {
        private readonly string resultFile;
        private readonly IUI io;

        public PlayerData(string resultFile)
        {
            this.resultFile = resultFile;
            this.io = new TextIO();
        }

        public List<IPlayer> GetPlayerData()
        {
            using StreamReader resultLog = new StreamReader(resultFile);

            List<IPlayer> playerList = new List<IPlayer>();


            playerList = SortPlayerData(resultLog);
            playerList = SortHighscoreList(playerList);

            return playerList;

        }

        private List<IPlayer> SortPlayerData(StreamReader playerData)
        {
            List<IPlayer> results = new List<IPlayer>();

            try
            {

                string line;
                string stringSeparator = "#&#";
                while ((line = playerData.ReadLine()) != null)
                {
                    string[] nameAndScore = line.Split(new string[] { stringSeparator }, StringSplitOptions.None);
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
                        results[pos].AddNewResult(guesses);
                    }
                }
                return results;

            }
            catch
            {
                return results;
            }
        }

        public List<IPlayer> SortHighscoreList(List<IPlayer> playerList)
        {
            playerList.Sort((p1, p2) => p1.Average().CompareTo(p2.Average()));

            return playerList;
        }

        public void SavePlayerData(string name, int guessCount)
        {
            try
            {
                StreamWriter result = new StreamWriter(resultFile, append: true);
                result.WriteLine(name + "#&#" + guessCount);
                result.Close();
            }
            catch
            {
                io.Print("Error occured, your recent game has not been saved.");
            }
        }


    }
}
