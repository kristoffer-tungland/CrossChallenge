using System;
using System.Threading.Tasks;
using CrossChallenge.Api.Models;
using CrossChallenge.Contracts.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CrossChallenge.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivityController : ControllerBase
    {
        private readonly ILogger<ActivityController> _logger;
        private readonly IActivityRepository _activityRepository;

        public ActivityController(ILogger<ActivityController> logger, IActivityRepository activityRepository)
        {
            _logger = logger;
            _activityRepository = activityRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetActivities()
        {
            return Ok(await _activityRepository.GetActivities());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetActivity(int id)
        {
            return Ok(await _activityRepository.GetActivity(id));
        }

        [HttpPost]
        public async Task<ActionResult> AddActivity(Activity activity)
        {
            return Ok(await _activityRepository.AddActivity(activity));
        }

        [HttpPut]
        public async Task<ActionResult> UpdateActivity(Activity activity)
        {
            return Ok(await _activityRepository.UpdateActivity(activity));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteActivity(int id)
        {
            try
            {
                await _activityRepository.DeleteActivity(id);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }

            return Ok();
        }
    }
}