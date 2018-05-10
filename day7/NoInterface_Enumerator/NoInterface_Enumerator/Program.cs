using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoInterface_Enumerator {
    struct Enumerator {
        string[] Colors;
        int Position;
        public Enumerator(string[] colors) {
            Colors = colors;
            Position = -1;
        }
        public string Current {
            get {
                if (Position < 0 || Position >= Colors.Length) {
                    throw new InvalidOperationException();
                } else {
                    return Colors[Position];
                }
            }
        }
        public bool MoveNext() {
            if (Colors != null && Position < Colors.Length - 1) {
                Position++;
                return true;
            } else {
                return false;
            }
        }
    }
    class NoInterface_Enumerator {
        string[] Colors;
        public NoInterface_Enumerator(params string[] colors) {
            Colors = colors;
        }
        public Enumerator GetEnumerator() {
            return new Enumerator(Colors);
        }
    }

    class Program {
        static void Main(string[] args) {
            var mc = new NoInterface_Enumerator("Red", "Orange", "Yellow", "Green", "Blue", "Indigo", "Purple");
            foreach (string color in mc)
                Console.WriteLine(color);
            Console.ReadKey();
        }
    }
}
