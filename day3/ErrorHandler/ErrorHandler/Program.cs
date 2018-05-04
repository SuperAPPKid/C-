using System;
using CS = System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErrorHandler {
    class OneException : Exception {
        public override string Message {
            get {
                return "OneException";
            }
        }
    }
    class TwoException : Exception {
        public override string Message {
            get {
                return "TwoException";
            }
        }
    }
    class WhatException : Exception {
        public override string Message {
            get {
                return "WhatException";
            }
        }
    }
    class Program {
        static void throwSomething(int a) {
            switch (a) {
                case 1:
                    throw new OneException();
                case 2:
                    throw new TwoException();
                default:
                    break;
            }
        }
        static void Main(string[] args) {
            try {
                throwSomething(2);
                try {
                    throw new WhatException();
                } catch {
                    throw;
                }
            } catch (OneException e) {
                CS.WriteLine($"Handling {e.Message}");
            } catch (TwoException e) {
                CS.WriteLine($"Handling {e.Message}");
            } catch (Exception e) {
                CS.WriteLine($"Handling {e.Message}!!!");
            } finally {
                CS.WriteLine("---final---");
            }

            CS.WriteLine("-----END-----");
            CS.ReadKey();
        }
    }
}
