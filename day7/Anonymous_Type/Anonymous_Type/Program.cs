using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anonymous_Type {
    class Program {
        class AClass {
            public int x;
            public int y;
            public int z;
            public AClass() { }
            public AClass(int x) { this.x = x; }
        }
        static void Main(string[] args) {
            var a1 = new AClass(1);
            var a2 = new AClass(2) { x = 3, y = 4, z = 5 };
            var a3 = new AClass() { x = 6, y = 7, z = 8 };
            var z = 'X';
            Console.WriteLine($"x = {a1.x}, y = {a1.y}, z = {a1.z}");
            Console.WriteLine($"x = {a2.x}, y = {a2.y}, z = {a2.z}");
            Console.WriteLine($"x = {a3.x}, y = {a3.y}, z = {a3.z}");

            //Anonymous_Type
            var anonymous = new { x= "good", a3.y, z };
            Console.WriteLine($"x = {anonymous.x}, y = {anonymous.y}, z = {anonymous.z}");
            Console.ReadKey();
        }
    }
}
