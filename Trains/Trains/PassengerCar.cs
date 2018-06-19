using System;

namespace Trains
{
    public class PassengerCar : Car
    {
        public PassengerCar(int maxPassengerCount)
        {
            MaxPassengerCount = maxPassengerCount;
        }

        public int MaxPassengerCount { get; }

        public int CurrentPassengerCount { get; set; }

        public Conductor Conductor { get; set; } = new Conductor();

        public override void Print()
        {
            base.Print();
            Console.Write($"{CurrentPassengerCount}/{MaxPassengerCount}, {Conductor.AllowedToDepart}");
        }
    }
}