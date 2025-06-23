using System;

namespace PW1
{
    public enum TrainStatus
    {
        EnRoute,
        Waiting,
        Docking,
        Docked
    }

    public abstract class BaseTrain
    {
        public string Identifier { get; private set; }
        public TrainStatus CurrentStatus { get; set; }
        public int MinutesUntilArrival { get; set; }
        public string Category { get; private set; }

        protected BaseTrain(string identifier, int arrivalMinutes, string category)
        {
            Identifier = identifier;
            MinutesUntilArrival = arrivalMinutes;
            CurrentStatus = TrainStatus.EnRoute;
            Category = category;
        }

        public virtual void UpdateArrivalTime(int minutes)
        {
            if (MinutesUntilArrival > 0)
            {
                MinutesUntilArrival -= minutes;
                if (MinutesUntilArrival < 0)
                    MinutesUntilArrival = 0;
            }
        }

        public override string ToString()
        {
            return $"[{Identifier}] Type: {Category}, Status: {CurrentStatus}, Arrival In: {MinutesUntilArrival} min";
        }
     }
}
