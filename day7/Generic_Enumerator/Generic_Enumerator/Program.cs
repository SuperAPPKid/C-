using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic_Enumerator {
    class Generic_Enumerator<T> : IEnumerable<T> {
        T[] Data;
        public Generic_Enumerator(params T[] args) {
            Data = args;
        }

        public IEnumerator<T> GetEnumerator() {
            return new DataEnumerator(Data);
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return new DataEnumerator(Data);
        }

        struct DataEnumerator : IEnumerator<T> {
            T[] Data;
            int Position;
            bool disposed;

            public DataEnumerator(T[] data) {
                Data = data;
                Position = -1;
                disposed = false;
            }

            public T Current {
                get {
                    if (Position < 0 || Position >= Data.Length) {
                        throw new InvalidOperationException();
                    } else {
                        return Data[Position];
                    }
                }
            }

            object IEnumerator.Current {
                get {
                    if (Position < 0 || Position >= Data.Length) {
                        throw new InvalidOperationException();
                    } else {
                        return Data[Position];
                    }
                }
            }

            public void Dispose() {

            }

            public bool MoveNext() {
                if (Data != null && Position < Data.Length - 1) {
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
            var mc = new Generic_Enumerator<string>("Red", "Orange", "Yellow", "Green", "Blue", "Indigo", "Purple");
            IEnumerable ie = (IEnumerable)mc;
            ie.GetEnumerator();
            foreach (string color in mc)
                Console.WriteLine(color);
            Console.ReadKey();
        }
    }
}
