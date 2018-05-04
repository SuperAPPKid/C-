using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace statement {
    class Program {
        static void Main(string[] args) {
            var str1 = @"123\n456\n789";
            var str2 = "123\n456\n789";
            var c = '\u54c8';
            Console.WriteLine($"str1:\n{str1}");
            Console.WriteLine($"str2:\n{str2}");
            Console.WriteLine($"c:\n{c}");
            var str3 = "abc";
            var str4 = str3;
            Console.WriteLine($"str3:\n{str3}");
            Console.WriteLine($"str4:\n{str4}");
            Console.WriteLine($"str3==str4?? {str3 == str4}");
            str4 = "abc";
            Console.WriteLine($"str3:\n{str3}");
            Console.WriteLine($"str4:\n{str4}");
            Console.WriteLine($"str3==str4?? {str3 == str4}");

            Type t = typeof(Console);
            Console.WriteLine($"Class: {"abc".GetType().Name}");
            FieldInfo[] fi = t.GetFields();
            MethodInfo[] mi = t.GetMethods();
            PropertyInfo[] pi = t.GetProperties();
            foreach (FieldInfo item in fi) {
                Console.WriteLine($"Field: {item}");
            }
            foreach (MethodInfo item in mi) {
                Console.WriteLine($"Method: {item}");
            }
            foreach (PropertyInfo item in pi) {
                Console.WriteLine($"Property: {item}");
            }
            

            Console.ReadKey();
        }
    }
}
