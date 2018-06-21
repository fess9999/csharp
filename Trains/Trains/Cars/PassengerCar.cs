using System;

namespace Trains.Cars
{
    public class PassengerCar : Car, IHasConductor
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