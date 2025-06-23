using System;
using System.IO;

namespace PW1
{
    class Program
    {
        static Station? station;

        static void Main(string[] args)
        {
            Console.WriteLine("Enter number of platforms:");
            if (int.TryParse(Console.ReadLine(), out int platformCount))
            {
                station = new Station(platformCount);
            }
            else
            {
                Console.WriteLine("Invalid number. Exiting.");
                return;
            }

            while (true)
            {
                Console.WriteLine("\nOptions:");
                Console.WriteLine("1 - Load trains from file");
                Console.WriteLine("2 - Start simulation");
                Console.WriteLine("3 - Display system state");
                Console.WriteLine("4 - Exit");
                Console.Write("Select option: ");

                string? input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        LoadTrains();
                        break;
                    case "2":
                        RunSimulation();
                        break;
                    case "3":
                        station?.DisplayStatus();
                        break;
                    case "4":
                        return;
                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }
            }
        }

        static void LoadTrains()
        {
            Console.WriteLine("Enter CSV file name:");
            string? filePath = Console.ReadLine();

            if (filePath == null || !File.Exists(filePath))
            {
                Console.WriteLine("File not found.");
                return;
            }

            try
            {
                var lines = File.ReadAllLines(filePath);
                foreach (var line in lines)
                {
                    var parts = line.Split(',');
                    if (parts.Length < 5)
                        continue;

                    string id = parts[0];
                    int arrival = int.Parse(parts[1]);
                    string type = parts[2].ToLower();

                    if (type == "passenger")
                    {
                        int carriages = int.Parse(parts[3]);
                        int cap = int.Parse(parts[4]);
                        station?.AddTrain(new PassengerTrain(id, arrival, carriages, cap));
                    }
                    else if (type == "freight")
                    {
                        int weight = int.Parse(parts[3]);
                        string cargo = parts[4];
                        station?.AddTrain(new FreightTrain(id, arrival, weight, cargo));
                    }
                }

                Console.WriteLine("Trains loaded successfully.");
            }
            catch
            {
                Console.WriteLine("Error loading the file. Format might be incorrect.");
            }
        }

        static void RunSimulation()
        {
            if (station == null)
                return;

            bool allDocked;
            do
            {
                station.AdvanceTick();
                station.DisplayStatus();
                allDocked = true;

                foreach (var train in station.Trains)
                {
                    if (train.CurrentStatus != TrainStatus.Docked)
                    {
                        allDocked = false;
                        break;
                    }
                }

                System.Threading.Thread.Sleep(1000);

            } while (!allDocked);

            Console.WriteLine("All trains are now docked. Simulation complete.");
        }
    }
}

