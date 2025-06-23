using System;

namespace PW1
{
    public class PassengerTrain : BaseTrain
    {
        public int NumberOfCarriages { get; private set; }
        public int Capacity { get; private set; }

        public PassengerTrain(string id, int arrivalTime, int carriages, int capacity)
            : base(id, arrivalTime, "passenger")
        {
            NumberOfCarriages = carriages;
            Capacity = capacity;
        }

        public override string ToString()
        {
            return base.ToString() + $", Carriages: {NumberOfCarriages}, Max Passengers: {Capacity}";
        }
    }
}
