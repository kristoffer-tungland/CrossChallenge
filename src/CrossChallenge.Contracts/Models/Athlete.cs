using CrossChallenge.Contracts.Enums;

namespace CrossChallenge.Contracts.Models
{
    public class Athlete
    {
        public int AthleteID { get; set; }

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public string Email { get; set; }

        public Gender Gender { get; set; }

    }
}