using System;

namespace Trains
{
    public class Train
    {
        private const int SpeedStep = 10;
        private Car[] cars;

        public Car[] Cars
        {
            get { return cars; }
        }

        public Train(string stationName)
        {
            cars = new Car[] {new LocomotiveCar()};
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
            var newSize = Cars.Length + newCars.Length;

            if (newSize > CarsLimit)
            {
                Console.WriteLine("You cannot couple these cars!");
                return;
            }

            Array.Resize(ref cars, newSize);
            newCars.CopyTo(Cars, Cars.Length - newCars.Length);
        }

        public bool AllowedToDepart
        {
            get
            {
                var allowed = true;
                foreach (var car in Cars)
                {
                    if (car is PassengerCar passengerCar && !passengerCar.Conductor.AllowedToDepart)
                        allowed = false;
                }

                return allowed;
            }
        }

        public void DecoupleCars(int carCount)
        {
            var newSize = Cars.Length - carCount;

            if (newSize < 1)
            {
                Console.WriteLine("You cannot decouple so many cars!");
                return;
            }

            Array.Resize(ref cars, newSize);
        }

        public void Print()
        {
            foreach (var car in Cars)
            {
                car.Print();
                Console.Write("-");
            }

            Console.WriteLine($" Station: {CurrentStation}, Speed {CurrentSpeed}");
        }
    }
}