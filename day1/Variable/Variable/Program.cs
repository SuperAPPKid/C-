using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Variable
{
    class Program
    {
        static void Main(string[] args)
        {
            short the_short = short.MaxValue;
            int the_int = int.MaxValue;
            long the_long = long.MaxValue;

            decimal the_decimal = 0.0m;
            float the_float = 0.0f;
            double the_double = 0.0d;
            bool the_bool = true;
            char the_char = 'a';
            Console.Write($"{the_decimal}\n{the_float}\n{the_double}\n{the_char}\n");

            Console.ReadKey();
        }
    }
    class the_class { }
    interface the_interface { }
    struct the_struct { }
    enum the_enum { }
    
}
