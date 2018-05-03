using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//註解
namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.WriteLine("Your Name?");
            string name = Console.ReadLine();
            Console.WriteLine($"Hello {name}!");
            Console.ReadKey();
        }
    }
}
