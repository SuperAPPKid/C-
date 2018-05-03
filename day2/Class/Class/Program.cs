using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bank;

namespace Class {
    class Program {
        static int globalVar;
        static void Main(string[] args) {
            Random rand = new Random();
            int localVar;
            //Console.WriteLine(localVar);
            Console.WriteLine(globalVar);
            var account = new BankAccount("Hank", rand.Next(10, 100) * 100);
            Console.WriteLine($"Account {account.Number} was created for {account.Owner} with {account.Balance} initial balance.");
            Console.WriteLine(BankAccount.publicStaticProperty);
            BankAccount.publicStaticMethod();
            //BankAccount.privateStaticMethod();
            
            for (int i = 0; i < 2; i++) {

                try {
                    account.MakeWithdrawal(1000, DateTime.Now, "Withdraw");
                } catch (Exception e) {
                    Console.WriteLine(e.ToString());
                }
            }
            Console.WriteLine($"Owner:{account.Owner},Number:{account.Number}");
            Console.WriteLine(account.GetAccountHistory());
            Console.ReadKey();
        }
    }
}
