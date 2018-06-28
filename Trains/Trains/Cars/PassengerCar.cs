using System;
using Trains.Attributes;

namespace Trains.Cars
{
    public class PassengerCar : Car, IHasConductor
    {
        public PassengerCar(int maxPassengerCount) => MaxPassengerCount = maxPassengerCount;

        public int MaxPassengerCount { get; }

        [ShoudBeZero]
        public int CurrentPassengerCount { get; set; }

        [ShoudNotBeNull]
        public Conductor Conductor { get; set; } = new Conductor();

        public override void Print()
        {
            base.Print();
            Console.Write($"{CurrentPassengerCount}/{MaxPassengerCount}, {Conductor?.AllowedToDepart}");
        }
    }
}