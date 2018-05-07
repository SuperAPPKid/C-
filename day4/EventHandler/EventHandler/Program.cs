using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Handler {
    public class MyTimerClass {
        public event EventHandler<MyEventArgs> Elapsed;
        //{
        //    add {}
        //    remove {}
        //}
        private void OnOneSecond(object source,EventArgs args) {
            if (Elapsed != null) {
                Elapsed(source, new MyEventArgs("GOGOGOGO"));
            }
        }
        private System.Timers.Timer MyTimer;
        public MyTimerClass() {
            MyTimer = new System.Timers.Timer();
            MyTimer.Elapsed += OnOneSecond;
            MyTimer.Interval = 1000;
            MyTimer.Enabled = true;
        }
    }
    public class ClassB {
        public static void TimeHandlerB(object source, MyEventArgs args) {
            Console.WriteLine(args.Message);
        }
    }
    public class MyEventArgs: EventArgs {
        public string Message;
        public MyEventArgs(string s) {
            this.Message = s;
        }
    }
    class Program {
        static void Main() {
            var mc = new MyTimerClass();
            mc.Elapsed += (object source, MyEventArgs args) => {
                Console.WriteLine("AAA");
            };
            mc.Elapsed += ClassB.TimeHandlerB;

            Thread.Sleep(5000);

            mc.Elapsed -= ClassB.TimeHandlerB;
            Console.WriteLine("BBB removed");
            Console.ReadKey();
        }
    }
}
