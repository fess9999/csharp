using System;

namespace Interfaces
{
    public class Fly : IFlyable
    {
        public void TakeOff()
        {
            Console.WriteLine("Just jump and airborne");
        }

        public int MaxHeight
        {
            get { return 10; }
        }

        public void Land()
        {
            Console.WriteLine("Smash into your glass");
        }
    }
}