using System;
using System.Collections.Generic;
using System.Linq;
using Trains.Cars;
using Trains.Exceptions;

namespace Trains
{
    public class Train
    {
        private const int SpeedStep = 10;

        public Stack<Car> Cars { get; set; }

        public List<string> GetAllowedToDepartCars() => 
            Cars.OfType<PassengerCar>()
            .Where(car => car.CurrentPassengerCount > 0 && car.Conductor.AllowedToDepart)
            .OrderBy(car => car.CurrentPassengerCount)
            .Select(car => $"{car.CurrentPassengerCount} {car.MaxPassengerCount}")
                .ToList();

        public Train(string stationName)
        {
            Cars = new Stack<Car>();
            Cars.Push(new LocomotiveCar());
            CurrentStation = stationName;
        }

        public int CurrentSpeed { get; set; }

        public string CurrentStation { get; set; }

        public static int RussiaSpeedLimit { get; } = 120;

        public static int CarsLimit { get; } = 100; 

        public void SpeedUp()
        {
            var newSpeed = CurrentSpeed + SpeedStep;
            if (newSpeed > RussiaSpeedLimit) throw new OverspeedException("Overspeed")
            {
                MaxSpeed = RussiaSpeedLimit
            };

            CurrentSpeed = newSpeed;
        }

        public void SpeedDown()
        {
            var newSpeed = CurrentSpeed - SpeedStep;
            CurrentSpeed = newSpeed < 0 ? 0 : newSpeed;
        }

        public void CoupleCars(params Car[] newCars)
        {
            var newSize = Cars.Count + newCars.Length;

            if (newSize > CarsLimit)
            {
                throw new CarsLimitException("Car limit reached")
                {
                    CarLimit = CarsLimit
                };
            }

            foreach (var newCar in newCars)
                Cars.Push(newCar);
        }

        public bool AllowedToDepart
        {
            get
            {
                var allowed = true;
                foreach (var car in Cars)
                {
                    if (car is IHasConductor conductorCar && !conductorCar.Conductor.AllowedToDepart)
                        allowed = false;
                }

                return allowed;
            }
        }

        public void DecoupleCars(int carCount)
        {
            var newSize = Cars.Count - carCount;

            if (newSize < 1)
            {
                Console.WriteLine("You cannot decouple so many cars!");
                return;
            }

            for (var i = 0; i < carCount; i++)
                Cars.Pop();
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