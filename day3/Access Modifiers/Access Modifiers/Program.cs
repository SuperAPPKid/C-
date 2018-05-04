using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Access_Modifiers {
    public class T1 {
        public static int publicInt;
        internal static int internalInt;
        private static int privateInt = 0;
        protected static int protectedInt = 100;
        static T1() {
            M1.publicInt = 1;
            M1.internalInt = 2;
            M2.publicInt = 3;
            M2.internalInt = 4;

            // Cannot access the private member privateInt in either class:
            // M1.privateInt = 2; //CS0122
        }

        public class M1 {
            public static int publicInt;
            internal static int internalInt;
            private static int privateInt = 0;
            protected static int protectedInt = 100;
        }

        private class M2 {
            public static int publicInt = 0;
            internal static int internalInt = 0;
            private static int privateInt = 0;
            protected static int protectedInt = 100;
        }
    }

    class MainClass:T1 {
        static void Main() {
            // Access is unlimited:
            T1.publicInt = 1;
            T1.internalInt = 2;
            T1.protectedInt = 5;

            // Error CS0122: inaccessible outside T1:
            // T1.privateInt = 3;  

            // Access is unlimited:
            T1.M1.publicInt = 1;

            // Accessible only in current assembly:
            T1.M1.internalInt = 2;

            // Error CS0122: CS0122  C# is inaccessible due to its protection level:
            //    T1.M1.protectedInt = 1;

            // Error CS0122: inaccessible outside M1:
            //    T1.M1.privateInt = 3; 

            // Error CS0122: inaccessible outside T1:
            //    T1.M2.publicInt = 1;

            // Error CS0122: inaccessible outside T1:
            //    T1.M2.internalInt = 2;

            // Error CS0122: inaccessible outside M2:
            //    T1.M2.privateInt = 3;

            AnotherNamespace.N1.internalInt = 99;

            // Keep the console open in debug mode.
            System.Console.WriteLine("Press any key to exit.");
            System.Console.ReadKey();

        }

        //CS0509 C# : cannot derive from sealed type
        //class try2_Inherit_Sealed_Class : AnotherNamespace.N1 { }
    }
}
namespace AnotherNamespace {
    public sealed class N1 {
        static internal int internalInt = 99;
    }
}
