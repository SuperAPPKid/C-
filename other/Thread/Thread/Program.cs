using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace MultiThread {
    public class SharedStateDemo {
        private int itemCount = 0;
        private object locker = new Object(); // 用於獨佔鎖定的物件

        public void Run() {
            var t1 = new Thread(AddToCart);
            var t2 = new Thread(AddToCart);

            t1.Start(300);
            t2.Start(100);
        }

        private void AddToCart(object simulateDelay) {
            Console.WriteLine("Enter thread {0}", // 顯示目前所在的執行緒編號
                Thread.CurrentThread.ManagedThreadId);
            lock (locker)  // 利用 locker 物件來鎖定程式區塊
            {
                itemCount++;

                Thread.Sleep((int)simulateDelay);
                Console.WriteLine("Items in cart: {0} on thread {1}",
                    itemCount, Thread.CurrentThread.ManagedThreadId);
            }
        }

    }
    class Program {
		
        static void ShowThreadInfo(string msg) {
            Console.WriteLine("T{0}: {1}",Thread.CurrentThread.ManagedThreadId, msg);
        }

		static void MyBackgroundTask(object param)
        {
            for (int i = 0; i < 500; i++)
            {
                Console.Write(param);
            }
        }

        static void Main(string[] args) {
            //var t1 = new Thread(()=> {
            //    for (int i = 0; i < 10; i++) {
            //        ShowThreadInfo("1");
            //    }
            //});
            //var t2 = new Thread(() => {
            //    for (int i = 0; i < 10; i++) {
            //        ShowThreadInfo("2");
            //    }
            //});
            //t1.Start();
            //t2.Start();


            //new SharedStateDemo().Run();

			Thread t1 = new Thread(MyBackgroundTask);
            Thread t2 = new Thread(MyBackgroundTask);
            Thread t3 = new Thread(MyBackgroundTask);

            t1.Start("X");
            t2.Start("Y");
            t3.Start("Z");

            t1.Join();
            t2.Join();
            t3.Join();

            for (int i = 0; i < 500; i++)
            {
                Console.Write(".");
            }

            Console.ReadKey();
        }

    }
}
