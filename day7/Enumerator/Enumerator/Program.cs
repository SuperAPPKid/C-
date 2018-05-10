using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enumerator {
    class NormalEnumerator : IEnumerable {
        string[] Colors;
        public NormalEnumerator(params string[] colors) {
            Colors = colors;
        }
        public IEnumerator GetEnumerator() {
            return new ColorEnumerator(Colors);
        }

        struct ColorEnumerator : IEnumerator {
            string[] Colors;
            int Position;

            public ColorEnumerator (string[] colors) {
                Colors = colors;
                Position = -1;
            }

            public object Current {
                get {
                    if (Position < 0 || Position >= Colors.Length) {
                        throw new InvalidOperationException();
                    } else {
                        return Colors[Position];
                    }
                }
            }

            public bool MoveNext() {
                if (Colors != null && Position < Colors.Length-1) {
                    Position++;
                    return true;
                } else {
                    return false;
                }
            }

            public void Reset() {
                Position = -1;
            }
        }
    }

    class Program {
        static void Main(string[] args) {
            var list = new List<string>();
            
            var mc = new NormalEnumerator("Red","Orange","Yellow","Green","Blue", "Indigo", "Purple");
            foreach (string color in mc)
                Console.WriteLine(color);
            Console.ReadKey();
        }
    }
}
