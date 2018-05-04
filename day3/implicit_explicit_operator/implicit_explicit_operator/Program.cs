using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace implicit_explicit_operator {
    class SpecialNumber {
        int _number;
        public int number { get { return this._number; } set { this._number = value > 100 ? 100 : value; } }

        //implicit
        //public static implicit operator int(SpecialNumber n) {
        //    Console.WriteLine("implicit SpecialNumber to int");
        //    return n.number;
        //}
        //public static implicit operator SpecialNumber(int n) {
        //    Console.WriteLine("implicit int to SpecialNumber");
        //    var s = new SpecialNumber();
        //    s.number = n;
        //    return s;
        //}

        //explicit
        public static explicit operator int(SpecialNumber n) {
            Console.WriteLine("explicit SpecialNumber to int");
            return n.number;
        }
        public static explicit operator SpecialNumber(int n) {
            Console.WriteLine("explicit int to SpecialNumber");
            var s = new SpecialNumber();
            s.number = n;
            return s;
        }

        //overload
        public static SpecialNumber operator + (SpecialNumber sp, int num) {
            Console.WriteLine("always 888");
            var s = new SpecialNumber();
            s.number = 88;
            return s;
        }
    }
    class Program {
        static void Main(string[] args) {
            //implicit
            //SpecialNumber sp = 500;
            //int num = sp;

            //explicit
            SpecialNumber sp = (SpecialNumber)500;
            int num = (int)sp;
            Console.WriteLine($"sp = {sp.number} , num = {num}");
            Console.WriteLine($"sp + num = {(int)(sp+num)}");
            Console.ReadKey();
        }
    }
}
