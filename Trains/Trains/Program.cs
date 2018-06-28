using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using MoreLinq;
using Newtonsoft.Json;
using Trains.Cars;

namespace Trains
{
    enum Stage
    {
        Initial,
        Formed,
        Boarded,
        MaxSpeed
    }

    internal class TrainState
    {
        public Train Train { get; set; }

        public Stage Stage { get; set; }
    }

    class Program
    {
        const string StationA = "Moscow";
        const string StationB = "St.Petersburg";

        private const string FileName = "train.json";

        private static readonly JsonSerializerSettings settings = new JsonSerializerSettings
        {
            Formatting = Formatting.Indented,
            TypeNameHandling = TypeNameHandling.Objects
        };

        private static void CheckForDepart(Train train) => Console.WriteLine(!train.AllowedToDepart
            ? "Train may not depart! Wait for the passengers seat"
            : "All passengers aboard. We may depart!");

        private static void SaveTrain(Train train, Stage stage) => File.WriteAllText(FileName,
            JsonConvert.SerializeObject(
                new TrainState
                {
                    Stage = stage,
                    Train = train
                }, settings));

        static void Main()
        {
            var trainState = RestoreState();
            var train = trainState.Train;

            var actions = new List<(Stage, Action)>
            {
                (Stage.Initial, () => train = FormTrain(StationA)),
                (Stage.Formed, () => Board(train)),
                (Stage.Boarded, () => SpeedUp(train)),
                (Stage.MaxSpeed, () => SpeedDown(StationB, train))
            };

            actions.SkipWhile(tuple => tuple.Item1 != trainState.Stage).ForEach(tuple => tuple.Item2());

            Console.ReadLine();
        }

        private static TrainState RestoreState() => File.Exists(FileName)
            ? JsonConvert.DeserializeObject<TrainState>(File.ReadAllText(FileName), settings)
            : new TrainState
            {
                Stage = Stage.Initial
            };

        private static void SpeedDown(string stationB, Train train)
        {
            Console.WriteLine($"Dear passengers, we are arriving at {stationB} in 5 nanoseconds");
            var previousSpeed = 0;
            while (train.CurrentSpeed != previousSpeed)
            {
                previousSpeed = train.CurrentSpeed;
                train.SpeedDown();
                train.Print();
            }

            train.CurrentStation = stationB;
            train.Print();

            Console.WriteLine("Thank you for choosing C# railways. We'll be glad to see you again!");

            SaveTrain(train, Stage.Initial);
        }

        private static void SpeedUp(Train train)
        {
            var keepAccelerating = true;
            train.OnOverspeed += speed =>
                Console.WriteLine(
                    $"This is dispatcher speaking. You are about overspeeding {speed} kph. Stop acceleration");
            train.OnOverspeed += speed => keepAccelerating = false;

            while (keepAccelerating)
            {
                train.SpeedUp();
                train.Print();
            }

            SaveTrain(train, Stage.MaxSpeed);
        }

        private static Train FormTrain(string stationA)
        {
            var train = new Train(stationA);
            train.Print();

            train.CoupleCars(new PassengerCar(100), new PassengerCar(30), new PostCar());
            train.CoupleCars(new FreightCar(130));
            //train.CoupleCars(new PassengerCar(52) { Conductor = null});
            //train.CoupleCars(new PostCar() { Conductor = null});
            //train.CoupleCars(new PassengerCar(88) { CurrentPassengerCount = 3} );
            train.Print();

            train.DecoupleCars(1);
            train.Print();

            Console.WriteLine($"We have {train.GetCarCount<PassengerCar>()} passenger cars");
            Console.WriteLine($"We have {train.GetCarCount<IHasConductor>()} conductor cars");
            //Console.WriteLine($"We have {train.GetCarCount<int>()} integer cars?!");

            Console.WriteLine();
            Console.WriteLine("Engineer, this is dispatcher speaking. You are allowed to depart on green signal!");

            CheckForDepart(train);

            SaveTrain(train, Stage.Formed);
            return train;
        }

        private static void Board(Train train)
        {
            Console.WriteLine("Boarding...");

            foreach (var car in train.Cars)
            {
                if (car is IHasConductor hasConductor)
                {
                    if (hasConductor is PassengerCar passengerCar)
                        passengerCar.CurrentPassengerCount = 12;
                    hasConductor.Conductor.AllowedToDepart = true;
                    car.Print();
                    Console.WriteLine(" ");
                }
            }

            CheckForDepart(train);

            SaveTrain(train, Stage.Boarded);
        }
    }
}