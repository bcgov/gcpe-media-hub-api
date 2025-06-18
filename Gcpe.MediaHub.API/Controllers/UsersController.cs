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
            var user = await _context.Users.FirstOrDefaultAsync(u => u.IDIR == idir);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }
    }
}