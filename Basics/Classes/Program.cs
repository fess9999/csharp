using System;

namespace Classes
{
    class Program
    {
        static void Main(string[] args)
        {

            var truck = new Truck(100, Car.Brand.MercedesBenz);
            var bus = new Bus();

            Car[] myCars = {truck, bus};

            foreach (var myCar in myCars)
            {

                var myTruck = (Truck) myCar;
                //var myTruck = myCar as Truck;
                myTruck.LoadCargo(90);

                myCar.PrintState();

            }


            Console.ReadLine();
        }

        
    }
}
