using System;

namespace Classes
{
    class Program
    {
        static void Main(string[] args)
        {

            Car car1;
            car1 = new Car();
            var car2 = new Car(Brand.Toyota, 90);
            car1.PrintState();
            car2.PrintState();

            car1.Speed = 100500;
            car2.SpeedUp();
            car1.PrintState();
            car2.PrintState();

            Console.ReadLine();
        }
    }

    public class Car
    {
        public readonly Brand brand;
        private int currentSpeed;
        private const int maxSpeed = 200;
        private bool engineStarted;

        static Car()
        {
            RussiaSpeedLimit = 91;
        }

        public Car()
        {
            engineStarted = true;
        }

        public Car(Brand brand) : this()
        {
            this.brand = brand;
        }

        public static int RussiaSpeedLimit { get; } = 90;

        public Car(Brand brand, int speed) : this(brand)
        {
            Speed = speed;
        }

        public void PrintState()
        {
            Console.WriteLine($"Engine started {engineStarted}, {brand} is going {Speed} kmh");
        }

        public int Speed
        {
            get { return currentSpeed; }
            set { currentSpeed = value > maxSpeed ? maxSpeed : value; }
        }

        public void SpeedUp()
        {
            currentSpeed++;
        }
    }

    public enum Brand
    {
        BMW,
        Honda,
        Toyota
    }
}
