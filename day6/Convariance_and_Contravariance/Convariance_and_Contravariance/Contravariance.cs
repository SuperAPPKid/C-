using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contravariance {
    class Food { }
    class Bamboo : Food { }
    delegate void Eater<in T>(T thing);
    class EaterClass<T> : IEat<T> {
        public void Eat(T thing) {
            throw new NotImplementedException();
        }
    }
    interface IEat<in T> {
        void Eat(T thing);
    }

}
