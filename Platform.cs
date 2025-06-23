using System;

namespace PW1
{
    public enum PlatformStatus
    {
        Free,
        Occupied
    }

    public class Platform
    {
        public string ID { get; private set; }
        public PlatformStatus Status { get; private set; }
        public BaseTrain? CurrentTrain { get; private set; }
        public int RemainingDockingTicks { get; private set; } = 0;

        public Platform(string id)
        {
            ID = id;
            Status = PlatformStatus.Free;
            CurrentTrain = null;
        }

        public bool AssignTrain(BaseTrain train)
        {
            if (Status == PlatformStatus.Free)
            {
                CurrentTrain = train;
                Status = PlatformStatus.Occupied;
                RemainingDockingTicks = 2;
                train.CurrentStatus = TrainStatus.Docking;
                return true;
            }
            return false;
        }

        public void Tick()
        {
            if (Status == PlatformStatus.Occupied && RemainingDockingTicks > 0)
            {
                RemainingDockingTicks--;
                if (RemainingDockingTicks == 0 && CurrentTrain != null)
                {
                    CurrentTrain.CurrentStatus = TrainStatus.Docked;
                }
            }
        }

        public override string ToString()
        {
            if (Status == PlatformStatus.Free)
                return $"Platform {ID}: Free";
            else
                return $"Platform {ID}: Occupied by {CurrentTrain?.Identifier}, {RemainingDockingTicks} ticks left";
        }
    }
}