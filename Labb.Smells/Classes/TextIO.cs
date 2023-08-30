using Labb.Smells.Interfaces;


namespace Labb.Smells.Classes
{
    public class TextIO : IUI
    {
        public string GetInput()
        {
            return Console.ReadLine();
        }

        public void Print(string message)
        {
            Console.WriteLine(message + "\n");
        }

        public void PrintStartMenu()
        {
            Console.WriteLine("Choose game: \n" +
        "1. MooGame (Digits are 0-9)\n" +
        "2. MasterMind (Digits are 0-6)");
        }

   
    }
}
