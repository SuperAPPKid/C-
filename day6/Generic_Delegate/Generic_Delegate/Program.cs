using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic_Delegate {
    delegate RT ManyFuncs<T, RT>(T value);
    class Program {
        static void Main(string[] args) {

            var thingsToDo = new ManyFuncs<uint,string> ( (value) => {
                Console.WriteLine("--------------------");
                return value.ToString();
            });
            thingsToDo += (value) => value % 2 == 0 ? "Even" : "Odd";
            thingsToDo += (value) => value > 10 ? "bigger than 10" : "Smaller than 10 or Equal to 10";

            foreach(var delgate in thingsToDo.GetInvocationList()) {
                Console.WriteLine(delgate.DynamicInvoke(100u)); 
            }
            foreach (var delgate in thingsToDo.GetInvocationList()) {
                Console.WriteLine(delgate.DynamicInvoke(7u));
            }

            Console.ReadKey();
        }
    }
}
