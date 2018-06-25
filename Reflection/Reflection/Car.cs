namespace Reflection
{
    public class Car : Entity
    {
        [NonDefault]
        public int MaxPassengers { get; set; }

        [NonDefault]
        public int WheelCount { get; set; }

        public int Speed { get; set; }

        public void SpeedUp(int increment) => Speed+=increment;

        public static int MaxRussiaSpeed  => 100;

        [NonDefault]
        public Driver Driver { get; set; }
    }
}