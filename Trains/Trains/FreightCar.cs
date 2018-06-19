using System;

namespace Trains
{
    public class FreightCar : Car
    {
        public int Capacity { get; }

        public FreightCar(int capacity)
        {
            Capacity = capacity;
        }

        public override void Print()
        {
            base.Print();
            Console.Write($"{Capacity} tons");
        }
    }
}