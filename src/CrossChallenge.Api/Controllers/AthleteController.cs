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
    public class AthleteController : ControllerBase
    {
        private readonly ILogger<AthleteController> _logger;
        private readonly IAthleteRepository _athleteRepository;

        public AthleteController(ILogger<AthleteController> logger, IAthleteRepository athleteRepository)
        {
            _logger = logger;
            _athleteRepository = athleteRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetAthletes()
        {
            return Ok(await _athleteRepository.GetAthletes());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetAthlete(int id)
        {
            return Ok(await _athleteRepository.GetAthlete(id));
        }

        [HttpPost]
        public async Task<ActionResult> AddAthlete(Athlete athlete)
        {
            return Ok(await _athleteRepository.AddAthlete(athlete));
        }

        [HttpPut]
        public async Task<ActionResult> UpdateAthlete(Athlete athlete)
        {
            return Ok(await _athleteRepository.UpdateAthlete(athlete));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAthlete(int id)
        {
            try
            {
                await _athleteRepository.DeleteAthlete(id);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }

            return Ok();
        }
    }
}