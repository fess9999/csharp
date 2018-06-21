namespace Trains.Cars
{
    public class PostCar : Car, IHasConductor
    {
        public Conductor Conductor { get; set; } = new Conductor();
    }
}