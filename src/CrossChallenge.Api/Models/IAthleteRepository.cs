using System.Collections.Generic;
using System.Threading.Tasks;
using CrossChallenge.Contracts.Models;

namespace CrossChallenge.Api.Models
{
    public interface IAthleteRepository
    {
        Task<IEnumerable<Athlete>> GetAthletes();
        Task<Athlete> GetAthlete(int athleteId);
        Task<Athlete> AddAthlete(Athlete athlete);
        Task<Athlete> UpdateAthlete(Athlete athlete);
        Task DeleteAthlete(int athleteId);
    }
}