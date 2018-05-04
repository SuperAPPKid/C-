using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace @using {
    class Program {
        static void Main(string[] args) {
            using (TextWriter tw = File.CreateText("Name.txt")) {
                tw.WriteLine("Hank Zhong");
                tw.WriteLine("go go go");
            }
            using (TextReader tr = File.OpenText("Name.txt")) {
                string someString;
                while ((someString= tr.ReadLine()) != null) {
                    Console.WriteLine(someString);
                }
            }
            Console.ReadKey();
        }
    }
}
