using System;
using System.Text.Json.Serialization;
using CrossChallenge.Contracts.Enums;
using Newtonsoft.Json.Converters;

namespace CrossChallenge.Contracts.Models
{
    public class Activity
    {
        public int ActivityID { get; set; }

        public string Name { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public ActivityType ActivityType { get; set; }

        public double Value { get; set; }

        public int Score { get; set; }

        public int AthleteID { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}