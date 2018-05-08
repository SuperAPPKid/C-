using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace where {
    interface aInterface { }
    interface bInterface { }
    interface cInterface<T, S> { }
    struct aStruct<T> { }
    delegate void aDelegate<T>(T x,int n);
    class aClass<T> { }
    class WhereExample<A,B1, B2, B3, RefType, KeyType, C> 
        where A : aClass<B1>    //三
        where RefType : class   //選
        where KeyType : struct  //一
        where B1 : aInterface
        where B2 : bInterface
        where B3 : cInterface<B1,B2>
        where C : new(){ }

    class Program {
        static void Main(string[] args) {
        }
    }
}
