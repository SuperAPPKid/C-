using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indexer {
    class aClass {
        int one = 1, two = 2, three = 3;
        public int this [string index] {
            get {
                switch (index) {
                    case "one":
                        return one;
                    case "two":
                        return two;
                    case "three":
                        return three;
                    default:
                        throw new ArgumentOutOfRangeException("run word");
                }
            }
        }
    }
    class Program {
        static void Main(string[] args) {
            var ac = new aClass();
            Console.WriteLine($"{ac["one"]}");
            Console.ReadKey();
        }
    }
}
