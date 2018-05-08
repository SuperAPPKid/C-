using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conversions {
    class C { public int value = 1; }
    class A { public int value = 1; }
    class B :A { new public int value = 2; }
    class Program {
        static void Main(string[] args) {
            //--------------------
            var aaa = new A();
            //var bbb = (B)aaa; //NG
            Console.WriteLine(aaa is B);
            Console.WriteLine(aaa as B);

            //--------------------
            A aaaa = null;
            var bbbb = (B)aaaa; //OK
            //Console.WriteLine(bbbb.value); //NG

            //-------------------- //OK
            var bb = new B();
            var aa = (A)bb;
            var cc = (B)aa;
            Console.WriteLine(aa.value);
            Console.WriteLine(bb.value);
            Console.WriteLine(cc.value);

            //boxing
            var i = 10;
            var oi = (object)i;
            Console.WriteLine($"i = {i} , oi = {oi}");
            i = 100;
            oi = 200;
            Console.WriteLine($"i = {i} , oi = {oi}");
            i = (int)oi;//unboxing
            Console.WriteLine($"i = {i} , oi = {oi}");
            Console.ReadKey();
        }
    }
}
