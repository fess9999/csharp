using System;

namespace Interfaces
{
    public class Plane : IFlyable
    {
        public void TakeOff()
        {
            Console.WriteLine("Taking a complex take off preps and doing that");
        }

        public int MaxHeight
        {
            get { return 10000; }
        }

        public void Land()
        {
            Console.WriteLine(
                "Descending, deploing flaps and gears, gently touching down the ground, getting applauses");
        }
    }
}