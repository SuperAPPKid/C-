using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace function {
    class aClass {
        public int value;
    }
    class Program {
        static void Main(string[] args) {
            int one = 1, two = 2;
            var three = new aClass();
            three.value = 3;
            aClass num ;

            sum(1 + 2, 3 + 4);
            sum(b: 1.0f,a: 2.0f);
            add5(one, three);
            Console.WriteLine($"one is {one}, three's value is {three.value} after add5()");
            swap(ref one, ref two);
            Console.WriteLine($"one is {one}, two is {two} after swap()");
            become4(out num);
            Console.WriteLine($"num'value is {num.value} after become4()");
            printAllArguments(1, 3, 5, 7, 8, 100, 55, 2);

            Console.ReadKey();
        }
        static void sum(int a ,int b) {
            Console.WriteLine($"{a} + {b} = {a + b} after sum()");
        }
        static void sum(float a, float b) {
            Console.WriteLine($"{a} + {b} = {a + b} after sum()");
        }

        static void add5(int a, aClass b) {
            a += 5;
            b.value += 5;
        }
        static void swap(ref int a,ref int b) {
            var temp = a;
            a = b;
            b = temp;
        }
        static void become4(out aClass a) {
            a = new aClass();
            a.value = 4;
        }
        static void printAllArguments(params int[] nums) {
            foreach (int num in nums) {
                Console.Write($"{num} ");
            }
        }
        
    }
}
