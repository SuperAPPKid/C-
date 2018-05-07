using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Struct_and_Enum {
    class Program {
        static void Main(string[] args) {
            var ss1 = new Point();
            var ss2 = new Point(8, 8);
            Console.WriteLine(ss1.x);
            Console.WriteLine(ss2.x);
            var color = Color.Red;
            Console.WriteLine(color.GetType().Name);
            var fifteen = Hex.SingleDeck | Hex.LargePictures | Hex.FancyNumbers | Hex.Animation;
            Console.WriteLine((fifteen&Hex.SingleDeck) == Hex.SingleDeck);
            Console.WriteLine(fifteen.HasFlag(Hex.SingleDeck));
            Console.WriteLine(fifteen.ToString());
            Console.ReadKey();
        }
        private struct Point {
            internal int x;
            internal int y;
            internal Point(int x,int y) {
                this.x = x;
                this.y = y;
            }
        } 
        private enum Color : uint {
            Red,Blue,Green
        }
        [Flags]
        private enum Hex : uint {
            SingleDeck = 0x01,
            LargePictures = 0x02,
            FancyNumbers = 0x04,
            Animation = 0x08
        }
    }
}
