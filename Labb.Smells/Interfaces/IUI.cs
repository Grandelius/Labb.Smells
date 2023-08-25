using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb.Smells.Interfaces
{
    public interface IUI
    {
        public void Print(string v)
        {
            Console.WriteLine();
        }

        public string GetInput()
        {
           return Console.ReadLine();
        }
    }
}
