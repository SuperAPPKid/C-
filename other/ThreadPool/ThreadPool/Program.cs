using System;
using System.Collections.Generic;
using System.Threading;

namespace ThreadPool {
    class Program {
        static void do100times(object arg) {
            for (var i = 1; i <= 100; i++)
                Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId,-3} : {(string)arg,-5} - ({i})");
        }
        static void Main(string[] args) {
            System.Threading.ThreadPool.QueueUserWorkItem(do100times, "Hello");
            System.Threading.ThreadPool.QueueUserWorkItem(do100times, "123");
            System.Threading.ThreadPool.QueueUserWorkItem(do100times, "Bye");
            Thread.Sleep(100);
            System.Threading.ThreadPool.QueueUserWorkItem(do100times, "Good");
            Thread.Sleep(100);
            System.Threading.ThreadPool.QueueUserWorkItem(do100times, "Bad");
            Console.ReadKey();
        }
    }
}
