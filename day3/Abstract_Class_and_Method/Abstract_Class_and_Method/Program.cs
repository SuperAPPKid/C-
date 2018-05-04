using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstract_Class_and_Method {
    sealed class SealedClass {
        public void SayHello() {
            Console.WriteLine("Hello");
        }
    }
    static class ExtendSealed {
        public static void SayHi(this SealedClass cc) {
            Console.WriteLine("HI");
        }
    }

    static class StaticClass {
        public static int a = 1;
    }
    abstract class AbstractClass {
        public void sayHi() {
            Console.WriteLine("HI!");
        }
        abstract public void saySomething();
    }
    class DerivedClass : AbstractClass {
        new public void sayHi() {
            Console.WriteLine("HI!HI!HI!");
        }
        public override void saySomething() {
            Console.WriteLine("go!go!go!");
        }
    }
    class Program {
        static void Main(string[] args) {
            //var a = new AbstractClass(); NG
            var b = new DerivedClass();
            b.sayHi();
            b.saySomething();
            var c = (AbstractClass)b;
            c.sayHi();
            c.saySomething();
            //var s = new StaticClass(); NG
            var l = new SealedClass();
            l.SayHello();
            l.SayHi();

            Console.ReadKey();
        }
    }
    
}
