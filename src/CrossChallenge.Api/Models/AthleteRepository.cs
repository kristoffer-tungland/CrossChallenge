using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CrossChallenge.Contracts.Models;
using Microsoft.EntityFrameworkCore;

namespace CrossChallenge.Api.Models
{
    public class AthleteRepository : IAthleteRepository
    {
        private readonly AppDbContext _appDbContext;

        public AthleteRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<IEnumerable<Athlete>> GetAthletes()
        {
            var result = await _appDbContext.Athletes.ToListAsync();
            return result;
        }

        public async Task<Athlete> GetAthlete(int athleteId)
        {
            var result = await _appDbContext.Athletes
                .FirstOrDefaultAsync(a => a.AthleteID == athleteId);

            return result;
        }

        public async Task<Athlete> AddAthlete(Athlete athlete)
        {
            var result = await _appDbContext.Athletes.AddAsync(athlete);
            await _appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Athlete> UpdateAthlete(Athlete athlete)
        {
            if (!(await GetAthlete(athlete.AthleteID) is { } destinationAthlete)) 
                throw new Exception("Can't find athlete");

            destinationAthlete.Email = athlete.Email;
            destinationAthlete.Firstname = athlete.Firstname;
            destinationAthlete.Lastname = athlete.Lastname;
            destinationAthlete.Gender = athlete.Gender;

            await _appDbContext.SaveChangesAsync();
            return destinationAthlete;

        }

        public async Task DeleteAthlete(int athleteId)
        {
            if (await GetAthlete(athleteId) is { } athlete)
            {
                _appDbContext.Athletes.Remove(athlete);
                await _appDbContext.SaveChangesAsync();
            }
        }
    }
}