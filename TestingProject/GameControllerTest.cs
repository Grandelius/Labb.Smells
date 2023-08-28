using Labb.Smells.Interfaces;
using Moq;

namespace Labb.Smells.Classes.Tests
{
    [TestClass]
    public class GameControllerTest
    {
  
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

            var gameController = new GameController(new Mock<IUI>().Object, new Mock<IPlayerData>().Object, new Mock<IRandomNumberGenerator>().Object);

            // Act
            string target = gameController.CreateTargetNumber();

            // Assert
            Assert.AreEqual("0123", target);
        }
    }
}
