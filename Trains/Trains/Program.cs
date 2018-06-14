using System;

namespace Trains
{
    class Program
    {
        static void Main()
        {
            const string stationA = "Moscow";
            var stationB = "St.Petersburg";

            var train = new Train(stationA);
            train.Print();

            train.CoupleCars(new Car(CarType.Passenger), new Car(CarType.Passenger), new Car(CarType.Post));
            train.CoupleCars(new Car(CarType.Freight));
            train.Print();

            train.DecoupleCars(1);
            train.Print();

            Console.WriteLine();
            Console.WriteLine("Engineer, this is dispatcher speaking. You are allowed to depart on green signal!");

            var previousSpeed = -1;

            while (train.CurrentSpeed != previousSpeed)
            {
                previousSpeed = train.CurrentSpeed;
                train.SpeedUp();
                train.Print();
            }

            Console.WriteLine($"Dear passengers, we are arriving at {stationB} in 5 nanoseconds");
            previousSpeed = 0;
            while (train.CurrentSpeed != previousSpeed)
            {
                previousSpeed = train.CurrentSpeed;
                train.SpeedDown();
                train.Print();
            }

            train.CurrentStation = stationB;
            train.Print();

            Console.WriteLine("Thank you for choosing C# railways. We'll be glad to see you again!");

            Console.ReadLine();
        }
    }
}
