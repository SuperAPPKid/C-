using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yield {
    class MyEnumerableClass<T> {
        T[] Data;
        public MyEnumerableClass(params T[] data) {
            this.Data = data;
        }
        public IEnumerable<T> Forward() {
            foreach(var value in Data) {
                yield return value;
            }
        }
        public IEnumerable<T> Reverse() {
            foreach (var value in Data.Reverse()) {
                yield return value;
            }
        }
    }
    class MyEnumeratorClass<T> {
        T[] Data;
        bool Forward;
        public MyEnumeratorClass(bool forward,params T[] data) {
            this.Forward = forward;
            this.Data = data;
        }
        public IEnumerator<T> GetEnumerator() {
            if (Forward) {
                foreach (var value in Data) {
                    yield return value;
                }
            } else {
                foreach (var value in Data.Reverse()) {
                    yield return value;
                }
            }
        }
    }
    class Program {
        static void Main(string[] args) {
            //foreach auto invoke GetEnumerator() to get Enumerator
            //yield + IEnumerator(name method Enumerator) -> Enumerator
            //yield + IEnumerable -> Enumerable(IEnumerable has method GetEnumerator()) -> Enumerator

            //yield
            //Before -> Running (return yield) <-> Suspended (wait for next invoke)
            //             ↓   (no more to yield)
            //           After

            var mEnumable = new MyEnumerableClass<string>("A","B","C","D", "E", "F");
            foreach (var value in mEnumable.Forward()) {
                Console.WriteLine(value);
            }
            Console.WriteLine("----------");
            foreach (var value in mEnumable.Reverse()) {
                Console.WriteLine(value);
            }
            Console.WriteLine("----------");
            var mEnumerator = new MyEnumeratorClass<int>(false,1,2,3,4,5,6);
            foreach (var value in mEnumerator) {
                Console.WriteLine(value);
            }
            Console.WriteLine("----------");
            Console.ReadKey();
        }
    }
}
