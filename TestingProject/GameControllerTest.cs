using Labb.Smells.Interfaces;
using Moq;

namespace Labb.Smells.Classes.Tests
{
    [TestClass]
    public class GameControllerTest
    {
        public GameController gamecontroller;

        public GameControllerTest()
        {
            this.gamecontroller = new GameController(new Mock<IUI>().Object,
                new Mock<IPlayerData>().Object,
                new Mock<IRandomNumberGenerator>().Object);
        }
  
        [TestMethod]
        public void Test_CreateTargetNumbers()
        {


            // Arrange the mocked RandomNumbers
            var randomNumberGeneratorMock =  new Mock<IRandomNumberGenerator>();
            randomNumberGeneratorMock.SetupSequence(x => x.Next(1, It.IsAny<int>()))
                .Returns(1)
                .Returns(2)
                .Returns(3)
                .Returns(4);

            string target = gamecontroller.CreateTargetNumber();

            Assert.AreEqual("0123", target);
        }

        [TestMethod]
        public void Test_CreateUserName()
        {
            var ioMock = new Mock<IUI>();
            ioMock.Setup(io => io.GetInput()).Returns("TestUser");

            gamecontroller.io = ioMock.Object;

            string userName = gamecontroller.CreateUserName();

            Assert.AreEqual("TestUser", userName);
            ioMock.Verify(io => io.Print("Enter your user name:"), Times.Once);
            ioMock.Verify(io => io.GetInput(), Times.Once);
        }

        [TestMethod]
       public void Test_PrintGuessResult_CorrectResult()
        {
            string target = "2345";
            string guess = "2345";

            string result = gamecontroller.PrintGuessResult(target, guess);

            Assert.AreEqual("BBBB,", result);
        }

        [TestMethod]

        public void Test_ValidGuess_Valid()
        {
            string guess = "1234";

            bool result = gamecontroller.ValidGuess(guess);

            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void Test_ValidGuess_Invalid()
        {
            string guess = "12AA";

            bool result = gamecontroller.ValidGuess(guess);

            Assert.AreEqual(false, result);
        }

        [TestMethod]

        public void Test_KeepPlaying_False()
        {
            var ioMock = new Mock<IUI>();
            ioMock.Setup(io => io.GetInput()).Returns("n");

            gamecontroller.io = ioMock.Object;

            bool result = gamecontroller.KeepPlaying();

            Assert.AreEqual(false, result);

            ioMock.Verify(io => io.GetInput(), Times.Once);

        }

        [TestMethod]

        public void Test_KeepPlaying_True()
        {
            var ioMock = new Mock<IUI>();
            ioMock.Setup(io => io.GetInput()).Returns("y");

            gamecontroller.io = ioMock.Object;

            bool result = gamecontroller.KeepPlaying();

            Assert.AreEqual(true, result);

            ioMock.Verify(io => io.GetInput(), Times.Once);
        }
    }
}
