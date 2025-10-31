using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;
using UserLibrary.Models;
using UserLibrary.Repos;

namespace UserWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IUserRepository userRepo;
        public UserController(IUserRepository userRepository)
        {
            userRepo = userRepository;
        }
        [HttpPost("{userId}/{password}")]
        public async Task<ActionResult> Post(string userId, string password)
        {
            try
            {
                await userRepo.RegisterAsync(userId, password);
                return Created();
            }
            catch (UserException ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{userId}/{password}")]
        public async Task<ActionResult> GetUser(string userId, string password)
        {
            try
            {
                UserRole userRole = await userRepo.LoginAsync(userId, password);
                return Ok(userRole);
            }
            catch (UserException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
