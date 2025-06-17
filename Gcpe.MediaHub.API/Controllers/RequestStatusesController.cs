using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Gcpe.MediaHub.API.Data;
using Gcpe.MediaHub.API.Models;

namespace Gcpe.MediaHub.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RequestStatusesController : ControllerBase
    {
        private readonly GcpeMediaHubAPIContext _context;

        public RequestStatusesController(GcpeMediaHubAPIContext context)
        {
            _context = context;
        }

        // GET: api/RequestStatuses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RequestStatus>>> GetRequestStatuses()
        {
            return await _context.RequestStatuses.ToListAsync();
        }
    }
}