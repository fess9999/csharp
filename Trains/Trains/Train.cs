using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using MoreLinq;
using Trains.Attributes;
using Trains.Cars;
using Trains.Exceptions;

namespace Trains
{
    public class Train
    {
        private const int SpeedStep = 10;

        public Train(string stationName)
        {
            Cars = new Stack<Car>();
            Cars.Push(new LocomotiveCar());
            CurrentStation = stationName;
        }

        public Stack<Car> Cars { get; set; }

        public int CurrentSpeed { get; set; }

        public string CurrentStation { get; set; }

        public static int RussiaSpeedLimit { get; } = 120;

        public static int CarsLimit { get; } = 100;

        public bool AllowedToDepart =>
            Cars.OfType<IHasConductor>().All(conductorCar => conductorCar.Conductor.AllowedToDepart);

        public event Action<int> OnOverspeed;

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

            newCars.ForEach(car =>
            {
                ValidateCar(car);
                Cars.Push(car);
            });
        }

        private void ValidateCar(Car car)
        {
            var properties = car.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public);

            var validations = new List<(Func<PropertyInfo, bool> Validate, Func<PropertyInfo, string> Message)>
            {
                (info => info.PropertyType == typeof(int) && info.IsDefined(typeof(ShoudBeZeroAttribute)) && (int) info.GetValue(car) != 0,
                    info => $"{info.Name} should be 0"),
                (info => !info.PropertyType.IsValueType && info.IsDefined(typeof(ShoudNotBeNullAttribute)) && info.GetValue(car) == null,
                    info => $"{info.Name} should not be null")
            };

            var failedValidation = properties
                .Select(info => validations.FirstOrDefault(tuple => tuple.Validate(info)).Message?.Invoke(info))
                .FirstOrDefault(message => !string.IsNullOrEmpty(message));

            if (failedValidation != null) throw new ValidationException(failedValidation);
        }

        public int GetCarCount<TCar>() => Cars.OfType<TCar>().Count();

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