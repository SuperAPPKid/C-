using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic_Method {
    sealed class Holder<T> {
        public T value { get; }
        public Holder(T v) {
            value = v;
        }
    }
    static class Holder_Extend {
        public static void print<T>(this Holder<T> h) {
            Console.WriteLine($"holder value is {h.value}");
        }
    }
    class Program { 
        static void swap<S>(ref S a,ref S b) //where S:struct 
            {
            var temp = a;
            a = b;
            b = temp;
        }
        static void Main(string[] args) {
            int a = 3, b = 10;
            Console.WriteLine($"a is {a}, b is {b}");
            swap<int>(ref a, ref b);
            Console.WriteLine($"a is {a}, b is {b}");

            string x = "xxx", y = "yyy";
            Console.WriteLine($"x is {x}, y is {y}");
            swap<string>(ref x, ref y);
            Console.WriteLine($"x is {x}, y is {y}");

            var h = new Holder<int>(100);
            h.print();

            Console.ReadKey();
        }
    }
}
