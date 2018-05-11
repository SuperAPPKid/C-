using System;
using System.Threading;

namespace Cancel_and_Timeout {
    class Program {
        static void Main(string[] args) {

            //ThreadPool.QueueUserWorkItem(state => MyTask(CancellationToken.None)); //CancellationToken.None cannot cancel

            using (CancellationTokenSource cts = new CancellationTokenSource(1000)) {
                Console.WriteLine("按 Enter 鍵可取消背景工作...");

                var cbReg2 = cts.Token.Register(() => Console.WriteLine("背景工作因為逾時而取消!"));
                var cbReg1 = cts.Token.Register(() => Console.WriteLine("使用者要求取消工作!"));
                
                ThreadPool.QueueUserWorkItem(state => MyTask(cts.Token));

                Console.ReadLine();

                cts.Cancel();
                cbReg1.Dispose();
                cbReg2.Dispose();
            }
            Console.ReadKey();
        }

        static void MyTask(CancellationToken token) {
            for (int i = 0; i < 1000; i++) {
                if (token.IsCancellationRequested) {
                    return;
                }
                Console.WriteLine(i);
                Thread.Sleep(200);
            }
            Console.WriteLine("MyTask 工作執行完畢。");
        }
    }
}
