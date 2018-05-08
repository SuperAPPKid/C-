using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface {
    interface IFly {
        void fly();
        double flySpeed { get;}
    }
    interface ISwim {
        void swim();
        double swimSpeed { get; }
    }
    abstract class Animal {
        public string nickName;
        public abstract void shout();
        public abstract string name { get; }
        public void eat() {
            Console.WriteLine($"{this.name} is eating...");
        } 
    }
    class Turtle : Animal, ISwim {
        public override string name {
            get {
                return "Turtle";
            }
        }
        public override void shout() {
            Console.WriteLine("mmmmm");
        }

        public double swimSpeed {
            get {
                return 10;
            }
        }

        public void swim() {
            Console.WriteLine($"{this.name} is swimming in {this.swimSpeed}km/hr...");
        }
        public Turtle(string nickName) {
            this.nickName = nickName;
            Console.WriteLine($"{nickName} born...");
        }
    }

    class Duck : Animal, IFly,ISwim {
        public override void shout() {
            Console.WriteLine("dadada");
        }

        public double flySpeed {
            get {
                return 80;
            }
        }

        public double swimSpeed {
            get {
                return 20;
            }
        }

        public override string name {
            get {
                return "Duck";
            }
        }

        public void fly() {
            Console.WriteLine($"{this.name} is flying in {this.flySpeed}km/hr...");
        }

        public void swim() {
            Console.WriteLine($"{this.name} is swimming in {this.swimSpeed}km/hr...");
        }
        public Duck(string nickName) {
            this.nickName = nickName;
            Console.WriteLine($"{nickName} born...");
        }
    }

    class Program {
        static void Main(string[] args) {
            var myTurtle = new Turtle(nickName:"Good Turtle");
            var myDock = new Duck(nickName: "Bad Duck");

            myDock.swim();
            myTurtle.swim();
            myDock.fly();
            
            var animals = new Animal[3];
            animals[0] = myDock;
            animals[1] = myTurtle;
            foreach(var animal in animals) {
                if (animal != null)
                    animal.shout();
                var canFly = animal as IFly;
                if (canFly != null)
                    canFly.fly();
                var canSwim = animal as ISwim;
                if (canSwim != null)
                    canSwim.swim();
            }

            //if ((IFly)myTurtle == null) //NG
            if (myTurtle as IFly == null) //OK
            {
                Console.WriteLine($"{myTurtle.name} cannot fly...");
            }
            Console.ReadKey();
        }
    }
}
