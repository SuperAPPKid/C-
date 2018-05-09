using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface {
    interface IFly {
        void fly();
        double speed { get;}
    }
    interface ISwim {
        void swim();
        double speed { get; }
    }
    abstract class Animal {
        public string nickName;
        public abstract void shout();
        public abstract string name { get; }
        public void eat() {
            Console.WriteLine($"{this.nickName} is eating...");
        } 
    }

    class Duck : Animal, IFly, ISwim {
        public override void shout() {
            Console.WriteLine("dadada");
        }

        double IFly.speed {
            get {
                return 80;
            }
        }

        double ISwim.speed {
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
            Console.WriteLine($"{this.nickName} is flying in {((IFly)this).speed}km/hr...");
        }

        public void swim() {
            Console.WriteLine($"{this.nickName} is swimming in {((ISwim)this).speed}km/hr...");
        }
        public Duck(string nickName) {
            this.nickName = nickName;
            Console.WriteLine($"{nickName} born...");
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

        public virtual double speed {
            get {
                return 10;
            }
        }

        public void swim() {
            Console.WriteLine($"{this.nickName} is swimming in {this.speed}km/hr...");
        }

        public Turtle(string nickName) {
            this.nickName = nickName;
            Console.WriteLine($"{nickName} born...");
        }
    }

    class SmallTurtle : Turtle {
        public override void shout() {
            Console.WriteLine(".......");
        }
        new public double speed {
            get {
                return 5;
            }
        }
        new public void swim() {
            Console.WriteLine($"{this.nickName} is swimming in {this.speed}km/hr...");
        }
        public SmallTurtle(string nickName) : base(nickName) {
        }
    }

    class Program {
        static void Main(string[] args) {
            var myTurtle = new Turtle(nickName:"Good Turtle");
            var myDock = new Duck(nickName: "Bad Duck");
            var myLT = new SmallTurtle(nickName:"Little Turtle");

            myLT.swim();

            var animals = new Animal[3];
            animals[0] = myDock;
            animals[1] = myTurtle;
            animals[2] = myLT;
            foreach(var animal in animals) {
                if (animal != null) {
                    animal.eat();
                    animal.shout();
                }
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
