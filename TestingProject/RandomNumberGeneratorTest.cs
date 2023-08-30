using Labb.Smells.Classes;
using Labb.Smells.Interfaces;


namespace TestingProject
{
    [TestClass]
    public class RandomNumberGeneratorTest
    {

        [TestMethod]
        public void Test_CreateTargetNumber_CorrectString()
        {
            
            IRandomNumberGenerator randomNumberGenerator = RandomNumberGeneratorFactory.CreateMooGameNumberGenerator(); // Create an instance of the class containing CreateTargetNumbers method

            string target = randomNumberGenerator.CreateTargetNumbers();
            Assert.AreEqual(4, target.Length); // Check if the length of the target string is 4

            foreach (char digitChar in target)
            {
                int digit;
                bool parseSuccess = int.TryParse(digitChar.ToString(), out digit);
                Assert.IsTrue(parseSuccess); // Check if each character in the target string can be successfully parsed as an int
                Assert.IsTrue(digit >= 0 && digit <= 9); // Check if the parsed digit is within the range 0-9
            }
        }
    }
}
