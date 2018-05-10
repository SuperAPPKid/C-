using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LINQ {
    class Country {
        public string Name;
        public int Index;
        public char Prefix {
            get {
                return Name.First();
            }
        }
    }
    class Program {
        static void Main(string[] args) {
            //Console.WriteLine(Directory.GetCurrentDirectory());
            var countries = new List<Country>();
            var numbers = new List<int>();
            var group1 = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var group2 = new[] { 4, 5, 6, 7, 8, 9, 10, 11, 12 };
            using (TextReader tr = File.OpenText(@"..\..\countries.txt")) {
                string someString;
                int i = 1;
                while ((someString = tr.ReadLine()) != null) {
                    countries.Add(new Country { Name = someString, Index = i++ });
                }
            }

            var r = new Random();
            for (int i = 1; i <= 10; i++) {
                numbers.Add(r.Next(1, countries.Count + 1));
            }

            var search1 = from n in numbers where n < 5 select n;
            var search2 = numbers.Where(x => x < 4);
            var search3 = (from n in numbers where n < 3 select n).Count();
            Console.WriteLine(search1.GetType());
            Console.WriteLine(search2.GetType());
            Console.WriteLine(search3.GetType());


            var query1 = from n in numbers
                         join c in countries on n equals c.Index
                         orderby c.Name descending
                         where n <= 100
                         select c;
            var query2 = from n in group1
                         from m in group2
                         where n == 3 || m == 5
                         select new { n, m, sum = n + m };
            var query3 = from n in group1
                         from m in group2
                         let remain = n % m
                         where remain == 1
                         select new { n, m, remain };
            var query4 = from n in group1
                         from m in group2
                         let sum = n + m
                         where n == 3 && sum > 5
                         select new { n, m, sum };
            var query5 = from c in countries
                         where c.Index < 100 && c.Index > 94
                         select new { c.Name };
            var query6 = from c in countries
                         where c.Index < 21
                         group c by c.Prefix;
            var query7 = from n in group1
                         join m in group2 on n equals m
                         into group3
                         from c in group3
                         select c;

            Console.WriteLine("----------- Random Numbers -----------");
            foreach (var n in numbers) {
                Console.WriteLine(n);
            }
            Console.WriteLine("--------------- query1 ---------------");
            foreach (var country in query1) {
                Console.WriteLine($"{country.Index,-3} - {country.Prefix,2} : {country.Name} ");
            }
            Console.WriteLine("--------------- query2 ---------------");
            foreach (var e in query2) {
                Console.WriteLine(e);
            }
            Console.WriteLine("--------------- query3 ---------------");
            foreach (var e in query3) {
                Console.WriteLine(e);
            }
            Console.WriteLine("--------------- query4 ---------------");
            foreach (var e in query4) {
                Console.WriteLine(e);
            }
            Console.WriteLine("--------------- query5 ---------------");
            foreach (var e in query5) {
                Console.WriteLine(e);
            }
            Console.WriteLine("--------------- query6 ---------------");
            foreach (var g in query6) {
                Console.WriteLine($" ************ {g.Key} ************");
                foreach (var e in g) {
                    Console.WriteLine($"  {e.Index,-3} - {e.Name} ");
                }
            }
            Console.WriteLine("--------------- query7 ---------------");
            foreach (var e in query7) {
                Console.WriteLine(e);
            }
            Console.WriteLine("------------- query7.??? -------------");
            var myDel = new Func<int, bool>(IsOdd);
            Console.WriteLine(query7.Count(myDel));
            Console.WriteLine(query7.Average((x)=>(x)));
            Console.WriteLine(query7.Sum());


            Console.ReadKey();
        }
        static bool IsOdd(int n) {
            return n % 2 == 1;
        }
    }
}
