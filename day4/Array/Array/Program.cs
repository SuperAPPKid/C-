using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//c# array is not mutable
namespace Array {
    class A { }
    class B :A { }
    class Program {
        static void Main(string[] args) {
            int[] arr1 = new int[7];
            int[,] arr2 = new int[3,3];
            var arr3 = new []{ 1, 2, 3 };
            var arr4 = new int[2][];
            arr4[0] = arr1;
            arr4[1] = arr3;
            foreach(var items in arr4) {
                Console.WriteLine(items);
                foreach(var item in items) {
                    Console.WriteLine(item);
                }
            }

            var intArr = new int[3,3];
            for (int i = 0; i < 3; i++) {
                for (int j = 0; j < 3; j++) {
                    intArr[i,j] = j+1+i*3;
                    Console.Write($"{intArr[i, j]},");
                }
                Console.WriteLine();
            }

            var arr5 = new A[] { new B(), new B(), new B() }; //ok
            //var arr6 = new B[] { new A(), new A(), new A() }; //ng

            Console.ReadKey();
        }
    }
}
