using System;

namespace Trains
{
    public class Car
    {
        private readonly CarType carType;

        public Car(CarType carType)
        {
            this.carType = carType;
        }

        public void Print()
        {
            Console.Write(carType);
        }
    }
}