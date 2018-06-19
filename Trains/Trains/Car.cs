using System;

namespace Trains
{
    public abstract class Car
    {
        public virtual void Print()
        {
            Console.Write($"{GetType().Name} ");
        }
    }
}