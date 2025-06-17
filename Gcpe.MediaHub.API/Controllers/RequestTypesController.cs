using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Gcpe.MediaHub.API.Data;
using Gcpe.MediaHub.API.Models;

namespace Gcpe.MediaHub.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RequestTypesController : ControllerBase
    {
        private readonly GcpeMediaHubAPIContext _context;

        public RequestTypesController(GcpeMediaHubAPIContext context)
        {
            _context = context;
        }

        // GET: api/RequestTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RequestType>>> GetRequestTypes()
        {
            return await _context.RequestTypes.ToListAsync();
        }
    }
}