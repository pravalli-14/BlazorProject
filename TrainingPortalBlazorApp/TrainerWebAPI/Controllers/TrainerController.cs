using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TrainerLibrary.Models;
using TrainerLibrary.Repos;

namespace TrainerWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TrainerController : ControllerBase
    {
        ITrainerRepository trainerRepo;
        public TrainerController(ITrainerRepository repository)
        {
            trainerRepo = repository;
        }
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            List<Trainer> trainers = await trainerRepo.GetAllTrainersAsync();
            return Ok(trainers);
        }
        [HttpGet("ByTrainerId/{trainerId}")]
        public async Task<ActionResult> Get(string trainerId)
        {
            try
            {
                Trainer trainer = await trainerRepo.GetTrainerAsync(trainerId);
                return Ok(trainer);
            }
            catch (TrainerException ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpGet("ByType/{type}")]
        public async Task<ActionResult> GetByType(string type)
        {
            try
            {
                List<Trainer> trainers = await trainerRepo.GetTrainerByTypeAsync(type);
                return Ok(trainers);
            }
            catch (TrainerException ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpPost("{token}")]
        public async Task<ActionResult> Post(string token,Trainer trainer)
        {
            try
            {
                await trainerRepo.NewTrainerAsync(trainer);
                HttpClient client = new HttpClient() { BaseAddress = new Uri("http://localhost:5077/api/Training/") };
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                client.PostAsJsonAsync("Trainer", new { trainer.TrainerId });
                return Created($"api/Trainer/{trainer.TrainerId}", trainer);
            }
            catch (TrainerException ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("{trainerId}")]
        public async Task<ActionResult> Put(string trainerId,Trainer trainer)
        {
            try
            {
                await trainerRepo.UpdateTrainerAsync(trainerId, trainer);
                return Ok(trainer);
            }
            catch (TrainerException ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{trainerId}")]
        public async Task<ActionResult> Delete(string trainerId)
        {
            try
            {
                await trainerRepo.DeleteTrainerAsync(trainerId);
                return Ok();
            }
            catch (TrainerException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
