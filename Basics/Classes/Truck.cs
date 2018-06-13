using System;

namespace Classes
{
    public class Truck : Car
    {
        private readonly int capacity;

        public Truck(int capacity, Brand brand) : base(brand)
        {
            this.capacity = capacity;
            axisCount = 3;
        }

        public int CurrentLoad { get; private set; }

        public void LoadCargo(int cargo)
        {
            if (CurrentLoad + cargo > capacity)
                Console.WriteLine("You cannot load any more cargo!");
            else
                CurrentLoad += cargo;
        }

        public new void PrintState()
        {
            Console.WriteLine($"{CurrentLoad} kg loaded {brand} truck is going {Speed} kmh");
        }

        public override int MaxSpeed { get; } = 70;

        public override void SpeedUp()
        {
            Speed++;
        }

        public void UnloadCargo(int cargo)
        {
            CurrentLoad -= cargo;
        }
    }
}