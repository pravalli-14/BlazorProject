using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TechnologyLibrary.Models;
using TechnologyLibrary.Repos;

namespace TechnologyWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TechnologyController : ControllerBase
    {
        ITechnologyRepository techRepo;
        public TechnologyController(ITechnologyRepository repository)
        {
            techRepo = repository;
        }
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            List<Technology> technologies = await techRepo.GetAllTechnologiesAsync();
            return Ok(technologies);
        }
        [HttpGet("ById/{technologyId}")]
        public async Task<ActionResult> GetById(string technologyId)
        {
            try
            {
                Technology technology = await techRepo.GetTechnologyAsync(technologyId);
                return Ok(technology);
            }
            catch (TechnologyException ex)
            {
                return NotFound(ex.Message); 
            }
        }
        [HttpGet("ByLevel/{level}")]
        public async Task<ActionResult> GetByLevel(string level)
        {
            try
            {
                List<Technology> technologies = await techRepo.GetTechnologyByLevelAsync(level);
                return Ok(technologies);
            }
            catch (TechnologyException ex) { 
                return NotFound(ex.Message);
            }
        }
        [HttpGet("ByDuration/{duration}")]
        public async Task<ActionResult> GetByDuration(int duration)
        {
            try
            {
                List<Technology> technologies = await techRepo.GetTechnologiesByDurationAsync(duration);
                return Ok(technologies);
            }
            catch (TechnologyException ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpPost("{token}")]
        public async Task<ActionResult> Post(string token,Technology technology)
        {
            try
            {
                await techRepo.NewTechnologyAsync(technology);
                HttpClient client = new HttpClient() { BaseAddress = new Uri("http://localhost:5077/api/Training/") };
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                client.PostAsJsonAsync("Technology", new { technology.TechnologyId });
                return Created($"api/Technology/{technology.TechnologyId}", technology);
            }
            catch (TechnologyException ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("{technologyId}")]
        public async Task<ActionResult> Put(string technologyId,Technology technology)
        {
            try
            {
                await techRepo.UpdateTechnologyAsync(technologyId, technology);
                return Ok(technology);
            }
            catch (TechnologyException ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{technologyId}")]
        public async Task<ActionResult> Delete(string technologyId)
        {
            try
            {
                await techRepo.DeleteTechnologyAsync(technologyId);
                return Ok();
            }
            catch (TechnologyException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
