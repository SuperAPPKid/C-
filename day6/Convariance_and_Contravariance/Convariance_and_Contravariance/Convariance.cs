using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Convariance {
    class Music { }
    class Metal : Music { string name; }
    delegate Music MusicCreater();
    delegate Metal MetalCreater();
    delegate T Creater<out T>();
    //delegate T Wrong_Creater<in T>();//NG
    interface ICreate<out T> {
        T create();
    }
    class CreaterClass<T> : ICreate<T> {
        public T create() {
            throw new NotImplementedException();
        }
    }
}
