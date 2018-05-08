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
        public string name { get; protected set; }
        public void eat() {
            Console.WriteLine($"{this.name} is eating...");
        } 
    }
    class Turtle : Animal, ISwim {
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
            this.name = "Turtle";
            this.nickName = nickName;
            Console.WriteLine($"{nickName} born...");
        }
    }

    class Dock : Animal, IFly,ISwim {
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

        public void fly() {
            Console.WriteLine($"{this.name} is flying in {this.flySpeed}km/hr...");
        }

        public void swim() {
            Console.WriteLine($"{this.name} is swimming in {this.swimSpeed}km/hr...");
        }
        public Dock(string nickName) {
            this.name = "Dock";
            this.nickName = nickName;
            Console.WriteLine($"{nickName} born...");
        }
    }

    class Program {
        static void Main(string[] args) {
            var myTurtle = new Turtle(nickName:"Good Turtle");
            var myDock = new Dock(nickName: "Bad Dock");

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
