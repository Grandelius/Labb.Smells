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

   
    }
}
