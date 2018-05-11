using System;
using System.Threading;
using System.Runtime.Remoting.Messaging;

namespace ajsdj {
    class Program {
        static void Main(string[] args) {
            CallContext.LogicalSetData("Time", DateTime.Now);

            ThreadPool.QueueUserWorkItem(
                state => {
                // 透過 CallContext 取得上游傳遞過來的環境資訊。
                Console.WriteLine("Time: {0}", CallContext.LogicalGetData("Time"));
                });

            // 抑制主執行緒的 execution context 流動機制。
            ExecutionContext.SuppressFlow();

            ThreadPool.QueueUserWorkItem(
                _ => {
                    Console.WriteLine("Time: {0}", CallContext.LogicalGetData("Time"));
                });

            // 恢復流動機制。
            ExecutionContext.RestoreFlow();

            Console.ReadKey();
        }
    }
}
