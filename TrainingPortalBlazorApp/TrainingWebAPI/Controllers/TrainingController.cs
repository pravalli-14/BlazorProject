using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TrainingLibrary.Models;
using TrainingLibrary.Repos;

namespace TrainingWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TrainingController : ControllerBase
    {
        ITrainingRepository trainingRepo;
        public TrainingController(ITrainingRepository repository)
        {
            trainingRepo = repository;
        }
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            List<Training> trainings = await trainingRepo.GetAllTrainingsAsync();
            return Ok(trainings);
        }
        [HttpGet("ByTrainingId/{trainingId}")]
        public async Task<ActionResult> GetById(string trainingId)
        {
            try
            {
                Training training = await trainingRepo.GetTrainingAsync(trainingId);
                return Ok(training);
            }
            catch (TrainingException ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpGet("ByTrainer/{trainerId}")]
        public async Task<ActionResult> GetByTrainer(string trainerId)
        {
            try
            {
                List<Training> trainings = await trainingRepo.GetTrainingByTrainerIdAsync(trainerId);
                return Ok(trainings);
            }
            catch (TrainingException ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpGet("ByTechnology/{technologyId}")]
        public async Task<ActionResult> GetByTechnology(string technologyId)
        {
            try
            {
                List<Training> trainings = await trainingRepo.GetTrainingByTechnologyIdAsync(technologyId);
                return Ok(trainings);
            }
            catch (TrainingException ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpPost]
        public async Task<ActionResult> Post(Training training)
        {
            try
            {
                await trainingRepo.AddTrainingAsync(training);
                return Created($"api/Training/{training.TrainingId}", training);
            }
            catch (TrainingException ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("Trainer")]
        public async Task<ActionResult> PostTrainer(Trainer trainer)
        {
            try
            {
                await trainingRepo.InsertTrainerAsync(trainer);
                return Created();
            }
            catch (TrainingException ex) { 
            return BadRequest(ex.Message);
            }
        }
        [HttpPost("Technology")]
        public async Task<ActionResult> PostTechnology(Technology technology)
        {
            try
            {
                await trainingRepo.InsertTechnologyAsync(technology);
                return Created();
            }
            catch (TrainingException ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("{trainingId}")]
        public async Task<ActionResult> Put(string trainingId,Training training)
        {
            try
            {
                await trainingRepo.UpdateTrainingAsync(trainingId, training);
                return Ok(training);
            }
            catch (TrainingException ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{trainingId}")]
        public async Task<ActionResult> Delete(string trainingId)
        {
            try
            {
                await trainingRepo.DeleteTrainingAsync(trainingId);
                return Ok();
            }
            catch (TrainingException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
