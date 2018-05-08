using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Overflow {
    class Program {
        const string formatter = "{0,30}{1,22:X16}";
        //const string formatter = "{0,25:E16}{1,22:X16}";
        public static void DoubleToLongBits(double argument) {
            long longValue;
            longValue = BitConverter.DoubleToInt64Bits(argument);

            Console.WriteLine(formatter, argument, longValue);
        }
        public static void IntToLongBits(int argument) {

            Console.WriteLine($"{argument,30}{argument,22:X16}");
        }
        static void Main(string[] args) {
            double d = 0.1d;
            float f = 0.1f;

            Console.WriteLine(formatter, "argument", "hexadecimal value");
            Console.WriteLine(formatter, "---------------------------", "------------------");
            DoubleToLongBits(d);
            DoubleToLongBits(f);
            DoubleToLongBits((float)d);
            DoubleToLongBits((double)f);
            DoubleToLongBits(double.MaxValue);
            DoubleToLongBits(double.MinValue);
            IntToLongBits(int.MaxValue);
            IntToLongBits(int.MinValue);
            IntToLongBits(char.MaxValue);
            IntToLongBits(char.MinValue);
            IntToLongBits((int)d);
            Console.ReadKey();
        }
    }
}
