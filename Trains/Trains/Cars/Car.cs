using System;

namespace Trains.Cars
{
    public abstract class Car
    {
        public virtual void Print() => Console.Write($"{GetType().Name} ");
    }
}