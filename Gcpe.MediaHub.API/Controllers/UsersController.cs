using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Gcpe.MediaHub.API.Data;
using Gcpe.MediaHub.API.Models;

namespace Gcpe.MediaHub.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly GcpeMediaHubAPIContext _context;

        public UsersController(GcpeMediaHubAPIContext context)
        {
            _context = context;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        // GET: api/Users/{idir}
        [HttpGet("{idir}")]
        public async Task<ActionResult<User>> GetUserByIdir(string idir)
        {
            try
            {
                // Verify idir format - shouldn't contain spaces
                if (idir.Contains(" "))
                {
                    return BadRequest("Invalid IDIR format");
                }

                // Get all users and filter in memory for case-insensitive comparison
                var users = await _context.Users.ToListAsync();
                var user = users.FirstOrDefault(u =>
                    u.IDIR.Equals(idir, StringComparison.OrdinalIgnoreCase));

                if (user == null)
                {
                    return NotFound($"User with IDIR '{idir}' not found");
                }

                return user;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error retrieving user with IDIR '{idir}': {ex.Message}");
                Console.Error.WriteLine(ex.StackTrace);
                return StatusCode(500, $"Error retrieving user: {ex.Message}");
            }
        }

        // GET: api/Users/byId/{id}
        [HttpGet("byId/{id}")]
        public async Task<ActionResult<User>> GetUserById(int id)
        {
            try
            {
                var user = await _context.Users.FindAsync(id);
                if (user == null)
                {
                    return NotFound($"User with Id '{id}' not found");
                }
                return user;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error retrieving user with Id '{id}': {ex.Message}");
                Console.Error.WriteLine(ex.StackTrace);
                return StatusCode(500, $"Error retrieving user: {ex.Message}");
            }
        }
    }
}