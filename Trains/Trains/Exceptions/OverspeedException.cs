using System;

namespace Trains.Exceptions
{
    public class OverspeedException : Exception
    {
        public OverspeedException(string message) : base(message)
        {
            
        }

        public int MaxSpeed { get; set; }
    }
}