using System;

namespace PW1
{
    public class Station
    {
        public List<Platform> Platforms { get; private set; }
        public List<BaseTrain> Trains { get; private set; }

        public Station(int platformCount)
        {
            Platforms = new List<Platform>();
            Trains = new List<BaseTrain>();
            for (int i = 1; i <= platformCount; i++)
            {
                Platforms.Add(new Platform($"PL{i:D2}"));
            }
        }

        public void AddTrain(BaseTrain train)
        {
            Trains.Add(train);
        }

        public void AdvanceTick()
        {
            foreach (var train in Trains)
            {
                if (train.CurrentStatus == TrainStatus.EnRoute)
                {
                    train.UpdateArrivalTime(15);
                    if (train.MinutesUntilArrival == 0)
                    {
                        Platform? freePlatform = Platforms.Find(p => p.Status == PlatformStatus.Free);
                        if (freePlatform != null)
                        {
                            freePlatform.AssignTrain(train);
                        }
                        else
                        {
                            train.CurrentStatus = TrainStatus.Waiting;
                        }
                    }
                }
            }

            foreach (var platform in Platforms)
            {
                platform.Tick();
            }
        }

        public void DisplayStatus()
        {
            Console.WriteLine("\n--- Station Status ---\n");
            Console.WriteLine("Trains:");
            foreach (var train in Trains)
            {
                Console.WriteLine(train);
            }
            Console.WriteLine("\nPlatforms:");
            foreach (var platform in Platforms)
            {
                Console.WriteLine(platform);
            }
            Console.WriteLine();
        }
    }
}