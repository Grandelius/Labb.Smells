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
            this.gamecontroller = new GameController(new Mock<IUI>().Object, new Mock<IPlayerData>().Object, new Mock<IRandomNumberGenerator>().Object);
        }
  
        [TestMethod]
        public void TestCreateTargetNumbers()
        {


            // Arrange
            var randomNumberGeneratorMock = new Mock<IRandomNumberGenerator>();
            randomNumberGeneratorMock.SetupSequence(x => x.Next(1, It.IsAny<int>()))
                .Returns(1)
                .Returns(2)
                .Returns(3)
                .Returns(4);

            //var gameController = new GameController(new Mock<IUI>().Object, new Mock<IPlayerData>().Object, new Mock<IRandomNumberGenerator>().Object);

            // Act
            string target = gamecontroller.CreateTargetNumber();

            // Assert
            Assert.AreEqual("0123", target);
        }

        [TestMethod]
        public void CreateUserName()
        {
            var ioMock = new Mock<IUI>();
            ioMock.Setup(io => io.GetInput()).Returns("TestUser");

            gamecontroller.io = ioMock.Object;

            //var playerDataMock = new Mock<IPlayerData>();
            //var randomNumberGeneratorMock = new Mock<IRandomNumberGenerator>();

            //var controller = new GameController(ioMock.Object, playerDataMock.Object, randomNumberGeneratorMock.Object);

            string userName = gamecontroller.CreateUserName(); /// INSPEKTERA IMORGON

            Assert.AreEqual("TestUser", userName);
            ioMock.Verify(io => io.Print("Enter your user name:"), Times.Once);
            ioMock.Verify(io => io.GetInput(), Times.Once);
        }
    }
}
