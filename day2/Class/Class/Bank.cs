using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank {
    //private,public,protected,internal,protected internal
    public class BankAccount {
        public string Number { get; }
        public string Owner { get; }
        private List<Transaction> allTransactions = new List<Transaction>();
        public int Balance {
            get
            {
                int balance = 0;
                foreach (var item in allTransactions)
                {
                    balance += item.Amount;
                }
                return balance;
            }
        }
        public static int publicStaticProperty = 100;
        //property&method default is private
        private static int accountNumberSeed = 100;

        public static void publicStaticMethod() {
            Console.WriteLine("I am Public Static Method");
        }
        private static void privateStaticMethod() {
            Console.WriteLine("I am Private Static Method");
        }

        //static construstor
        static BankAccount() {
            Console.WriteLine("Bank Class was Born.");
        }

        public BankAccount(string name, int initialBalance) {
            this.Owner = name;
            MakeDeposit(initialBalance, DateTime.Now, "Initial balance");
            this.Number = accountNumberSeed.ToString("00000000");
            accountNumberSeed++;
        }

        ~BankAccount() {
            Console.WriteLine("Bank Class was Dead.");
            Console.ReadKey();
        }

        public void MakeDeposit(int amount, DateTime date, string note) {
            if (amount <= 0) {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of deposit must be positive");
            }
            var deposit = new Transaction(amount, date, note);
            allTransactions.Add(deposit);
            
        }

        public void MakeWithdrawal(int amount, DateTime date, string note) {
            if (amount <= 0) {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of withdrawal must be positive");
            }
            if (Balance - amount < 0) {
                throw new InvalidOperationException("Not sufficient funds for this withdrawal");
            }
            var withdrawal = new Transaction(-amount, date, note);
            allTransactions.Add(withdrawal);
        }

        public string GetAccountHistory() {
            var report = new System.Text.StringBuilder();

            report.AppendLine("Date\t\tAmount\tNote");
            foreach (var item in allTransactions) {
                report.AppendLine($"{item.Date.ToShortDateString()}\t{item.Amount}\t{item.Notes}");
            }

            return report.ToString();
        }
    }
    public class Transaction {
        public int Amount { get; }
        public DateTime Date { get; }
        public string Notes { get; }

        public Transaction(int amount, DateTime date, string note) {
            this.Amount = amount;
            this.Date = date;
            this.Notes = note;
        }
    }
}
