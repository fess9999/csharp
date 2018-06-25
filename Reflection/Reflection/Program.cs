using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Reflection;
using MoreLinq;
using Newtonsoft.Json;

namespace Reflection
{
    class Program
    {
        static void Main(string[] args)
        {
            InspectingTypes();
            //WorkingWithType();
            //NonDefaultValidation();
            //MaxValueValidation();

            //SerializeObjects();
            //DeserializeObjects();

            Console.ReadLine();
        }

        private static void DeserializeObjects()
        {
            var entities = JsonConvert.DeserializeObject<List<Entity>>(File.ReadAllText("myEntities.json"),
                new JsonSerializerSettings
                {
                    Formatting = Formatting.Indented,
                    TypeNameHandling = TypeNameHandling.Objects
                });
        }

        private static void SerializeObjects()
        {
            var entities = new List<Entity>
            {
                new Car
                {
                    Driver = new Driver {Age = 30, Name = "Alex"},
                    WheelCount = 4,
                    MaxPassengers = 7,
                    Speed = 100
                },
                new DieselTrain {CarCount = 23, Description = "Awesome diesel train", Power = 3000}
            };

            var serialized = JsonConvert.SerializeObject(entities,
                new JsonSerializerSettings
                {
                    Formatting = Formatting.Indented,
                    TypeNameHandling = TypeNameHandling.Objects
                });

            File.WriteAllText("myEntities.json", serialized);
        }

        private static void MaxValueValidation()
        {
            var train = new DieselTrain
            {
                CarCount = 100500
            };

            var properties = train.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public)
                .Where(info => info.PropertyType == typeof(int))
                .Select(info => (PropertyInfo: info, MaxValueAttribute: info.GetCustomAttribute<MaxValueAttribute>()))
                .Where(tuple => tuple.MaxValueAttribute != null)
                .ToList();

            properties.ForEach(tuple =>
            {
                if ((int) tuple.PropertyInfo.GetValue(train) > tuple.MaxValueAttribute.MaxValue)
                    throw new ValidationException(
                        $"Property {tuple.PropertyInfo.Name} must not have greater than {tuple.MaxValueAttribute.MaxValue}");
            });

            Console.WriteLine($"Validation for {train.GetType().Name} passed!");
        }

        private static void NonDefaultValidation()
        {
            var car = new Car
            {
                //    Driver = new Driver(),
                MaxPassengers = 5
                //    WheelCount = 4
            };

            var steamTrain = new SteamTrain();
            //{
            //    CarCount = 4
            //};

            var dieselTrain = new DieselTrain();
            //{
            //    CarCount = 3
            //};

            ValidateEntity(car);
        }

        private static void ValidateEntity(Entity entity)
        {
            var properties = entity.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public)
                .Where(info => info.IsDefined(typeof(NonDefaultAttribute))).ToList();

            var failedProperty = properties.FirstOrDefault(info =>
            {
                var propertyValue = info.GetValue(entity);
                var defaultValue = info.PropertyType.IsValueType ? Activator.CreateInstance(info.PropertyType) : null;

                return propertyValue.Equals(defaultValue);
            });

            if (failedProperty != null)
                throw new ValidationException($"Property {failedProperty.Name} must not have a default value but does");

            Console.WriteLine($"Validation for {entity.GetType().Name} passed!");
        }

        private static void WorkingWithType()
        {
            var car = new Car();

            var type = car.GetType();

            var propertyInfo = type.GetProperty(nameof(Car.WheelCount));

            Console.WriteLine($"Wheel Count: {propertyInfo.GetValue(car)}");
            propertyInfo.SetValue(car, 6);
            Console.WriteLine($"Wheel Count: {car.WheelCount}");

            var methodInfo = type.GetMethod(nameof(Car.SpeedUp));
            Console.WriteLine($"Speed: {car.Speed}");
            methodInfo.Invoke(car, new object[] {10});
            Console.WriteLine($"Speed: {car.Speed}");
        }

        private static void InspectingTypes()
        {
            var car = new Car();

            var carType1 = typeof(Car);
            var carType2 = car.GetType();

            Console.WriteLine(carType1 == carType2);
            Console.WriteLine(carType2);
            Console.WriteLine($"Abstract: {carType2.IsAbstract}");

            var properties = carType2.GetProperties(BindingFlags.Instance | BindingFlags.Public);

            Console.WriteLine("Properties:");
            properties.ForEach(info => Console.WriteLine(info.Name));

            var methods = carType2.GetMethods(BindingFlags.Instance | BindingFlags.Public);

            Console.WriteLine();
            Console.WriteLine("Methods:");
            methods.ForEach(info => Console.WriteLine(info.Name));
        }
    }
}