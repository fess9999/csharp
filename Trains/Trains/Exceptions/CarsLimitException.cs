using System;

namespace Trains.Exceptions
{
    public class CarsLimitException : Exception
    {
        public CarsLimitException(string message) : base(message)
        {

        }

        public int CarLimit { get; set; }
    }
}