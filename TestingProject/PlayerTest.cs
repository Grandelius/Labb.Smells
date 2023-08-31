using Labb.Smells.Interfaces;

namespace Labb.Smells.Classes.Tests
{
    [TestClass]
    public class PlayerTests
    {
        public IPlayer player;
        public PlayerTests ()
        {
            this.player = new Player("Jonte", 6); // NumberOfGames is set with 1 when creating the player.
        }

        [TestMethod]

        public void TestAddNewResult()
        {
            int guesses = 1;

            player.AddNewResult(guesses);

            Assert.AreEqual(7, player.TotalGuess);
            Assert.AreEqual(2, player.NumberOfGames);

        }

        [TestMethod]
        public void TestAverage()
        {
            player.NumberOfGames = 2;

           double result = player.Average();

            Assert.AreEqual(3, result);
        }

    }
}
