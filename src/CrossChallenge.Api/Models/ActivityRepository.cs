using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CrossChallenge.Contracts.Models;
using Microsoft.EntityFrameworkCore;

namespace CrossChallenge.Api.Models
{
    public class ActivityRepository : IActivityRepository
    {
        private readonly AppDbContext _appDbContext;

        public ActivityRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<IEnumerable<Activity>> GetActivities()
        {
            var result = await _appDbContext.Activities.ToListAsync();
            return result;
        }

        public async Task<Activity> GetActivity(int activityId)
        {
            var result = await _appDbContext.Activities
                .FirstOrDefaultAsync(a => a.ActivityID == activityId);

            return result;
        }

        public async Task<Activity> AddActivity(Activity activity)
        {
            var result = await _appDbContext.Activities.AddAsync(activity);
            await _appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Activity> UpdateActivity(Activity activity)
        {
            if (!(await GetActivity(activity.ActivityID) is { } destinationActivity)) 
                throw new Exception("Can't find activity");

            destinationActivity.AthleteID = activity.AthleteID;
            destinationActivity.Name = activity.Name;
            destinationActivity.ActivityType = activity.ActivityType;
            destinationActivity.Value = activity.Value;
            destinationActivity.Score = activity.Score;
            destinationActivity.StartTime = activity.StartTime;
            destinationActivity.EndTime = activity.EndTime;

            await _appDbContext.SaveChangesAsync();
            return destinationActivity;

        }

        public async Task DeleteActivity(int activityId)
        {
            if (await GetActivity(activityId) is { } activity)
            {
                _appDbContext.Activities.Remove(activity);
                await _appDbContext.SaveChangesAsync();
            }
        }
    }
}