using System;

namespace Trains
{
    class Program
    {
        private static void CheckForDepart(Train train)
        {
            Console.WriteLine(!train.AllowedToDepart
                ? "Train may not depart! Wait for the passengers seat"
                : "All passengers aboard. We may depart!");
        }

        static void Main()
        {
            const string stationA = "Moscow";
            var stationB = "St.Petersburg";

            var train = new Train(stationA);
            train.Print();

            train.CoupleCars(new PassengerCar(100), new PassengerCar(30), new PostCar());
            train.CoupleCars(new FreightCar(130));
            train.Print();

            train.DecoupleCars(1);
            train.Print();

            Console.WriteLine();
            Console.WriteLine("Engineer, this is dispatcher speaking. You are allowed to depart on green signal!");

            CheckForDepart(train);
            Console.WriteLine("Boarding...");

            foreach (var car in train.Cars)
            {
                if (car is PassengerCar passengerCar)
                {
                    passengerCar.CurrentPassengerCount = 12;
                    passengerCar.Conductor.AllowedToDepart = true;
                    passengerCar.Print();
                    Console.WriteLine(" ");
                }
            }

            CheckForDepart(train);

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
