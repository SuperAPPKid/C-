using System;
using System.Threading;
using System.Threading.Tasks;

namespace program
{
    class MainClass
    {
		static void Main(string[] args) {
            // 寫法 1 - .NET 2 開始提供
			//ThreadPool.QueueUserWorkItem(state => MyTask());
            //ThreadPool.QueueUserWorkItem(state => MyTask(1));
            
            // 寫法 2 - .NET 4 開始提供 Task 類別。
			//var t1 = new Task(MyTask);   // 等同於 new Task(new Action(MyTask));
			//var t2 = new Task(() => MyTask(2));
			//t1.Start();
			//t2.Start();

            // 寫法 3 - 也可以用靜態方法直接建立並開始執行工作。
			//Task.Factory.StartNew(MyTask);
			//Task.Factory.StartNew(() => MyTask(3));
			//Task.Factory.StartNew(MyTask, 3);
			//Task.Factory.StartNew(new Action<Object>(MyTask), 3);

            // 寫法 4 - .NET 4.5 的 Task 類別新增了靜態方法 Run。
			//Task.Run(new Action(MyTask));
            //Task.Run(() => MyTask(4));
            
			string url = "https://www.huanlintalk.com/";
            var task = new Task<int>(GetContentLength, url);    // 建立工作。
            
			task.Start();   // 起始工作。
            
			int length = task.Result;   // 取得結果。
            Console.WriteLine("Content length: {0}", length);

			Console.ReadKey();
        }
        static int GetContentLength(object state)
        {
            var client = new System.Net.Http.HttpClient();
            var url = state as string;
            return client.GetStringAsync(url).Result.Length;
        }

		static void MyTask()
        {
            Console.WriteLine("工作執行緒 #{0}", Thread.CurrentThread.ManagedThreadId);
        }
        static void MyTask(int num) {
			Console.WriteLine($"({num})工作執行緒 #{Thread.CurrentThread.ManagedThreadId}" );
        }

		static void MyTask(Object state)
        {
            int num = (int)state;
			Console.WriteLine($"({num})工作執行緒 #{Thread.CurrentThread.ManagedThreadId}");
        }
    }
}
