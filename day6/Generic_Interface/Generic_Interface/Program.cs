using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic_Interface {
    interface MyInterface<T> {
        void Print(T value);
    }
    class A : MyInterface<int>,MyInterface<string> {
        public void Print(string value) {
            Console.WriteLine($"String: {value}");
        }

        public void Print(int value) {
            Console.WriteLine($"Number: {value}");
        }
    }
    class B<S> : MyInterface<S> {
        public void Print(S value) {
            Console.WriteLine($"{value.GetType()}: {value}");
        }
    }
    class P { }
    class S :P { }
    class Program {
        static P func(P p) {
            Console.WriteLine("OK");
            return new P();
        }
        static void Main(string[] args) {
            var a1 = new A();
            var a2 = new A();
            var bb = new B<double>();
            a1.Print(123);
            a2.Print(123.ToString());
            bb.Print(123.0);

            func(new P());
            func(new S());
            Console.ReadKey();
        }
    }
}
