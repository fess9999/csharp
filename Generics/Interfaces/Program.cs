using System;
using System.Collections;
using System.Collections.Generic;

namespace Interfaces
{
    class Program
    {
        static void Main(string[] args)
        {
            SimpleFlights();
            //EnumerableFlights();
            //ArrayListFlights();

            Console.ReadLine();
        }

        private static void GenericFlights()
        {
            var list = new List<IFlyable>
            {
                new Fly(), new Fly(), new Plane()
            };

            foreach (var flyable in list)
            {
                Fly(flyable);
            }
        }

        private static void ArrayListFlights()
        {
            var myPlane = new Plane();
            var arrayList = new ArrayList {new Fly(), myPlane};
            Console.WriteLine($"Count: {arrayList.Count}");

            arrayList.Add(new Plane());
            Console.WriteLine($"Count: {arrayList.Count}");

            Console.WriteLine($"Contains my plane: {arrayList.Contains(myPlane)}");

            foreach (IFlyable thing in arrayList)
            {
                Fly(thing);
            }
        }

        private static void EnumerableFlights()
        {
            var allFlyableThings = new FlyableThings(new Fly(), new Plane(), new Fly());

            foreach (IFlyable thing in allFlyableThings)
            {
                Fly(thing);
            }
        }

        private static void SimpleFlights()
        {
            Fly(new Fly());
            Fly(new Plane());
        }

        private static void Fly(IFlyable flyable)
        {
            flyable.TakeOff();
            Console.WriteLine($"Flying at the {flyable.MaxHeight} height");
            flyable.Land();
        }
    }
}
