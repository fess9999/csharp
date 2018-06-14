using System;

namespace Trains
{
    public class Train
    {
        private const int SpeedStep = 10;

        private Car[] cars;

        public Train(string stationName)
        {
            cars = new[] {new Car(CarType.Locomotive)};
            CurrentStation = stationName;
        }

        public int CurrentSpeed { get; set; }

        public string CurrentStation { get; set; }

        public static int RussiaSpeedLimit { get; } = 120;

        public static int CarsLimit { get; } = 100; 

        public void SpeedUp()
        {
            var newSpeed = CurrentSpeed + SpeedStep;
            CurrentSpeed = newSpeed > RussiaSpeedLimit ? RussiaSpeedLimit : newSpeed;
        }

        public void SpeedDown()
        {
            var newSpeed = CurrentSpeed - SpeedStep;
            CurrentSpeed = newSpeed < 0 ? 0 : newSpeed;
        }

        public void CoupleCars(params Car[] newCars)
        {
            var newSize = cars.Length + newCars.Length;

            if (newSize > CarsLimit)
            {
                Console.WriteLine("You cannot couple these cars!");
                return;
            }

            Array.Resize(ref cars, newSize);
            newCars.CopyTo(cars, cars.Length - newCars.Length);
        }

        public void DecoupleCars(int carCount)
        {
            var newSize = cars.Length - carCount;

            if (newSize < 1)
            {
                Console.WriteLine("You cannot decouple so many cars!");
                return;
            }

            Array.Resize(ref cars, newSize);
        }

        public void Print()
        {
            foreach (var car in cars)
            {
                car.Print();
                Console.Write("-");
            }

            Console.WriteLine($" Station: {CurrentStation}, Speed {CurrentSpeed}");
        }
    }
}