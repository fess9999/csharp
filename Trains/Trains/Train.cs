using System;
using System.Collections.Generic;
using System.Linq;
using MoreLinq;
using Trains.Cars;
using Trains.Exceptions;

namespace Trains
{
    public class Train
    {
        private const int SpeedStep = 10;

        public event Action<int> OnOverspeed;

        public Stack<Car> Cars { get; set; }

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

            if (newSpeed > RussiaSpeedLimit)
            {
                OnOverspeed?.Invoke(RussiaSpeedLimit);
                return;
            }

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

            newCars.ForEach(car => Cars.Push(car));
        }

        public int GetCarCount<TCar>() => Cars.OfType<TCar>().Count();

        public bool AllowedToDepart => Cars.OfType<IHasConductor>().All(conductorCar => conductorCar.Conductor.AllowedToDepart);
        //{
        //    get
        //    {
        //        var allowed = true;
        //        foreach (var car in Cars)
        //        {
        //            if (car is IHasConductor conductorCar && !conductorCar.Conductor.AllowedToDepart)
        //                allowed = false;
        //        }

        //        return allowed;
        //    }
        //}

        public void DecoupleCars(int carCount)
        {
            var newSize = Cars.Count - carCount;

            if (newSize < 1)
            {
                Console.WriteLine("You cannot decouple so many cars!");
                return;
            }

            Enumerable.Range(0, carCount).ForEach(i => Cars.Pop());
        }

        public void Print()
        {
            Cars.ForEach(car =>
            {
                car.Print();
                Console.Write("-");
            });

            Console.WriteLine($" Station: {CurrentStation}, Speed {CurrentSpeed}");
        }
    }
}