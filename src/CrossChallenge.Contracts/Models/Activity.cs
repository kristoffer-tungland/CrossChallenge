using System;
using CrossChallenge.Contracts.Enums;

namespace CrossChallenge.Contracts.Models
{
    public class Activity
    {
        public int ActivityID { get; set; }

        public string Name { get; set; }

        public ActivityType ActivityType { get; set; }

        public double Value { get; set; }

        public int Score { get; set; }

        public int AthleteID { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}