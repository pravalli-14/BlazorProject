using EmployeeLibrary.Models;
using EmployeeLibrary.Repos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EmployeeWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EmployeeController : ControllerBase
    {
        IEmployeeRepository empRepo;
        public EmployeeController(IEmployeeRepository repository)
        {
            empRepo = repository;
        }
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            List<Employee> employees = await empRepo.GetAllEmployeesAsync();
            return Ok(employees);
        }
        [HttpGet("EmpId/{empId}")]
        public async Task<ActionResult> Get(string empId)
        {
            try
            {
                Employee employee = await empRepo.GetEmployeeByIdAsync(empId);
                return Ok(employee);
            }
            catch (EmployeeException ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpGet("EmpDesignation/{designation}")]
        public async Task<ActionResult> GetByDesignation(string designation)
        {
            try
            {
                List<Employee> employees = await empRepo.GetEmployeesByDesignationAsync(designation);
                return Ok(employees);
            }
            catch (EmployeeException ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpPost("{token}")]
        public async Task<ActionResult> Post(string token,Employee employee)
        {
            try
            {
                await empRepo.AddEmployeeAsync(employee);
                HttpClient client = new HttpClient() { BaseAddress = new Uri("http://localhost:5077/api/Trainee/") };
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                await client.PostAsJsonAsync("Employee", new { employee.EmpId });
                return Created($"api/Employee/{employee.EmpId}", employee);
            }
            catch (EmployeeException ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("{empId}")]
        public async Task<ActionResult> Put(string empId,Employee employee)
        {
            try
            {
                await empRepo.UpdateEmployeeAsync(empId, employee);
                return Ok(employee);
            }
            catch (EmployeeException ex) {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{empId}")]
        public async Task<ActionResult> Delete(string empId)
        {
            try
            {
                await empRepo.DeleteEmployeeAsync(empId);
                return Ok();
            }
            catch (EmployeeException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
