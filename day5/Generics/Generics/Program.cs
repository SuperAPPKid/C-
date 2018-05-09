using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics {
    class MyStack<T> {
        int StackPointer = 0;
        int MaxStock = 10;
        T[] StackArray;
        bool IsFull {
            get {
                return StackPointer >= MaxStock;
            }
        }
        bool IsEmpty {
            get {
                return StackPointer <= 0;
            }
        }

        public void Push(T x) {
            Console.WriteLine($"PUSH {x}");
            if (!IsFull) {
                StackArray[StackPointer] = x;
                StackPointer++;
            } else {
                Console.WriteLine("FULL");
            }
        }
        public T Pop() {
            if (IsEmpty) {
                Console.WriteLine("EMPTY");
                return StackArray[0];
            } else {
                var temp = StackPointer;
                StackPointer--;
                Console.WriteLine($"POP {temp}");
                return StackArray[temp];
            }
        }
        public void Print() {
            for(int i = StackPointer-1; i >= 0; i--) {
                Console.WriteLine($"--Value:{StackArray[i]}");
            }
        }

        public MyStack() {
            StackArray = new T[MaxStock];
        }
    }

    struct ValueData<T> {
        public T Data { get; }
        public ValueData(T value) {
            Data = value;
        }
        public void Print() {
            Console.WriteLine($"--Data:{Data}");
        }
    }

    struct SimpleStruct {
        int a,b;
        public SimpleStruct(int a ,int b) {
            this.a = a;
            this.b = b;
        }
    }

    class Program {
        static void Main(string[] args) {
            var msInt = new MyStack<int>();
            var msString = new MyStack<string>();
            msInt.Push(1);
            msInt.Push(2);
            msInt.Push(3);
            msInt.Print();
            msInt.Pop();
            msInt.Pop();
            msInt.Pop();
            //var x = msInt.Pop();
            msInt.Print();
            //Console.WriteLine($"{x}");

            var vdString = new ValueData<string>("Happy Birthday");
            var st = new SimpleStruct(123, 456);
            var vdStruct = new ValueData<SimpleStruct>(st);
            vdString.Print();
            vdStruct.Print();

            Console.ReadKey();
        }
    }
}
