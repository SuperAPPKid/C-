using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance {
    class Parant {
        public int old = 50;
        virtual public void saySomething() {
            Console.WriteLine("I'm Dad.");
        }
        public Parant() {
            Console.WriteLine("Parant!!");
        }
        public Parant(int a) {
            Console.WriteLine("Parant!!!!");
        }
    }
    class Son:Parant {
        new public int old = 20;
        public int parentOld {
            get {
                return base.old;
            }
            set {
                base.old = value;
            }
        }
        new public void saySomething() {
            Console.WriteLine("I'm Son.");
        }
        public Son():this(80) {
            Console.WriteLine("Son!!");
        }
        public Son(int a):base(a) {
            this.old = a;
            Console.WriteLine("Son!!!!");
        }
    }


    class A {
        public string v = "AAA";
        public void func() {
            Console.WriteLine($"{this} : {this.v}");
        }
    }
    class B : A {
        new public string v = "BBB";
    }

    class Program {
        static void Main(string[] args) {
            //var son = new Son(18);
            //var oldSon = new Son();
            //var parant = (Parant)son;

            //Console.WriteLine($"son:{son.old}");
            //Console.WriteLine($"oldSon:{oldSon.old}");
            //son.parentOld = 40;
            //Console.WriteLine($"son's parant:{son.parentOld}");
            //Console.WriteLine($"parant:{parant.old}");

            //son.saySomething();
            //parant.saySomething();

            A aaa = new A();
            B bbb = new B();
            aaa.func();
            bbb.func();
            Console.ReadKey();
        }
    }
}
