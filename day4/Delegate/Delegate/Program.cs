using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegate {
    delegate double MathAction(double num);
    delegate void ShowAction(params double[] nums);
    class Program {
        static double Double(double input) {
            Console.WriteLine("multByTwo...");
            return input * 2;
        }
        static void ShowParams(params double[] nums) {
            foreach(var num in nums) {
                Console.Write($"{num} ");
            }
            Console.WriteLine();
        }

        static void Main(string[] args) {
            MathAction ma1 = new MathAction(Double);
            MathAction ma2 = delegate (double num) { //Anonymous Methods
                Console.WriteLine("addByThree...");
                return num + 3;
            };
            MathAction ma3 = x => { //lambda expression
                Console.WriteLine("become100..."); 
                return 100;
            }; 
            MathAction ma4 = ma3 + ma1;
            ShowAction ma5 = ShowParams;
            ShowAction ma6 = delegate (double[] nums) {
                var sum = 0d;
                foreach (var num in nums) {
                    sum += num;
                }
                Console.WriteLine($"sum: {sum}");
            };
            //life cycle
            ShowAction ma7;
            {
                int y = 100;
                ma7 = nums => Console.WriteLine($"x: {y}");
            }
            //y = 1000;
            double multByTwo = ma1(4.5d);
            Console.WriteLine($"multByTwo: {multByTwo}");
            double addByThree = ma2(5d);
            Console.WriteLine($"addByThree: {addByThree}");
            double become100 = ma3(12d);
            Console.WriteLine($"become100: {become100}");
            double become100_and_multByTwo = ma4(4);
            Console.WriteLine($"become100_and_multByTwo: {become100_and_multByTwo}");
            ma5(1, 2, 3, 4, 5, 6, 7, 8, 9);
            ma6(1, 3, 5, 7);
            //Console.WriteLine($"x: {y}");//NG y is dead
            ma7();//y in ma7 is still alive
            Console.ReadKey();
        }
    }
}
