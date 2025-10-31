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
    public class TraineeController : ControllerBase
    {
        ITraineeRepository traineeRepo;
        public TraineeController(ITraineeRepository traineeRepository)
        {
            traineeRepo = traineeRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetALl()
        {
            List<Trainee> trainees = await traineeRepo.GetAllTraineesAsync();
            return Ok(trainees);
        }
        [HttpGet("{trainingId}/{empId}")]
        public async Task<ActionResult> Get(string trainingId, string empId)
        {
            try
            {
                Trainee trainee = await traineeRepo.GetTraineeAsync(trainingId, empId);
                return Ok(trainee);
            }
            catch (TrainingException ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpGet("ById/{empId}")]
        public async Task<ActionResult> GetById(string empId)
        {
            try
            {
                List<Trainee> trainees = await traineeRepo.GetTraineesByEmpIdAsync(empId);
                return Ok(trainees);
            }
            catch (TrainingException ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpGet("ByTraining/{trainingId}")]
        public async Task<ActionResult> GetByTrainingId(string trainingId)
        {
            try
            {
                List<Trainee> trainees = await traineeRepo.GetTraineesByTrainingIdAsync(trainingId);
                return Ok(trainees);
            }
            catch (TrainingException ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpGet("ByStatus/{status}")]
        public async Task<ActionResult> GetByStatus(string status)
        {
            try
            {
                List<Trainee> trainees = await traineeRepo.GetTraineesByStatusAsync(status);
                return Ok(trainees);
            }
            catch (TrainingException ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpPost]
        public async Task<ActionResult> Post(Trainee trainee)
        {
            try
            {
                await traineeRepo.AddTraineeAsync(trainee);
                return Created($"api/Trainee/{trainee.TrainingId}/{trainee.EmpId}", trainee);
            }
            catch (TrainingException ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("Employee")]
        public async Task<ActionResult> PostEmployee(Employee employee)
        {
            try
            {
                await traineeRepo.InsertEmployee(employee);
                return Created();
            }
            catch (TrainingException ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("{trainingId}/{empId}/{status}")]
        public async Task<ActionResult> Put(string trainingId, string empId, string status)
        {
            try
            {
                await traineeRepo.UpdateTraineeAsync(trainingId, empId, status);
                return Ok();
            }
            catch (TrainingException ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{trainingId}/{empId}")]
        public async Task<ActionResult> Delete(string trainingId, string empId)
        {
            try
            {
                await traineeRepo.DeleteTraineeAsync(trainingId, empId);
                return Ok();
            }
            catch (TrainingException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
