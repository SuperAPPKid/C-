using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event {
    public delegate void MyEventHandler(string msg);//委託類型聲明
    class MyButton {
        public event MyEventHandler Click;//事件聲明
        //public MyEventHandler Click;//NG must have event key word
        private string msg;
        public void OnClick() { //觸發事件的代碼
            if (Click != null) {
                Click("我點擊了：" + msg);
            }
        }
        public MyButton(string msg) {
            this.msg = msg;
        }

    }
    class Program {
        static void Main(string[] args) {
            MyButton mb = new MyButton("MyButton對象");
            mb.Click += MyButton_Click;//事件註冊
            //mb.Click("Click為公共委託對象，可任意觸發執行委託方法，而無需觸發OnClick方法");//click like this is NG
            mb.OnClick();
            mb.OnClick();
            mb.OnClick();
            mb.OnClick();
            mb.OnClick();
            Console.ReadKey();
        }
        private static void MyButton_Click(string msg) { //處理程序聲明
            Console.WriteLine(msg);
        }
    }
}
