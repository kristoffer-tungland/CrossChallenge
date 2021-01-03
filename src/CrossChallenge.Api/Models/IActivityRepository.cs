using System.Collections.Generic;
using System.Threading.Tasks;
using CrossChallenge.Contracts.Models;

namespace CrossChallenge.Api.Models
{
    public interface IActivityRepository
    {
        Task<IEnumerable<Activity>> GetActivities();
        Task<Activity> GetActivity(int activityId);
        Task<Activity> AddActivity(Activity activity);
        Task<Activity> UpdateActivity(Activity activity);
        Task DeleteActivity(int activityId);
    }
}