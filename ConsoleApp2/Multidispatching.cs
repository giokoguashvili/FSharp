using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public interface IMulty
    {
        int DoSomething(int a);
        int DoSomething(string a);
        string DoSomething(char ch);
    }


    public class A : IMulty
    {
        public int DoSomething(int a)
        {
            return 1;
        }

        public int DoSomething(string a)
        {
            return 2;
        }

        public string DoSomething(char ch)
        {
            return "3";
        }
    }

    class Program1
    {
        class Thing { }
        class Asteroid : Thing { }
        class Spaceship : Thing { }


        static void CollideWithImpl(Asteroid x, Asteroid y)
        {
            Console.WriteLine("Asteroid hits an Asteroid");
        }


        static void CollideWithImpl(Asteroid x, Spaceship y)
        {
            Console.WriteLine("Asteroid hits a Spaceship");
        }


        static void CollideWithImpl(Spaceship x, Asteroid y)
        {
            Console.WriteLine("Spaceship hits an Asteroid");
        }


        static void CollideWithImpl(Spaceship x, Spaceship y)
        {
            Console.WriteLine("Spaceship hits a Spaceship");
        }


        static void CollideWith(Thing x, Thing y)
        {
            dynamic a = x;
            dynamic b = y;
            CollideWithImpl(a, b);
        }


        static void Run()
        {
            var asteroid = new Asteroid();
            var spaceship = new Spaceship();

            CollideWith(asteroid, spaceship);
            CollideWith(spaceship, spaceship);
            Console.ReadLine();
        }
    }
}
