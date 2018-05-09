using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Convariance;
using Contravariance;
//https://pic3.zhimg.com/80/5a939c8f301a3078173e3b0e4a24f360_hd.jpg
namespace Convariance_and_Contravariance {
    
    class Program {
        static Music musicCreater() {
            return new Music();
        }
        static Metal metalCreater() {
            return new Metal();
        }
        
        static void Main(string[] args) {
            //C# method is Invariant
            MusicCreater mu1 = musicCreater;
            //MetalCreater me1 = mu1;
            MetalCreater me2 = metalCreater;
            //MusicCreater mu2 = me2;

            //Convariance
            //Creater<Music> mu3 = musicCreater;
            //Creater<Metal> me3 = mu3;//get music include metal or classic or pop NG
            Creater<Metal> me4 = metalCreater;
            Creater<Music> mu4 = me4;//get metal, metal is music

            MusicCreater mu5 = metalCreater; // (out is not nessary)
            //MetalCreater me5 = musicCreater;

            CreaterClass<Metal> me6 = new CreaterClass<Metal>();
            ICreate<Music> imusic = me6;
            //CreaterClass<Music> mu6 = new CreaterClass<Music>();
            //ICreate<Metal> imetal = mu6;

            //Contravariance
            //Eater<Bamboo> ba1 = x => { };
            //Eater<Food> fo1 = ba1;   // dispose food, not only bamboo but also other thing is food too
            Eater<Food> fo2 = x => { };
            Eater<Bamboo> ba2 = fo2; // dispose bamboo, bamboo is food

            //EaterClass<Bamboo> ba3 = new EaterClass<Bamboo>();
            //IEat<Food> ifood = ba3;
            EaterClass<Food> fo3 = new EaterClass<Food>();
            IEat<Bamboo> ibamboo = fo3;
        }
    }
}
