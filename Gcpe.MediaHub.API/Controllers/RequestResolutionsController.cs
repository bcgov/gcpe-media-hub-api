using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Gcpe.MediaHub.API.Data;
using Gcpe.MediaHub.API.Models;

namespace Gcpe.MediaHub.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RequestResolutionsController : ControllerBase
    {
        private readonly GcpeMediaHubAPIContext _context;

        public RequestResolutionsController(GcpeMediaHubAPIContext context)
        {
            _context = context;
        }

        // GET: api/RequestResolutions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RequestResolution>>> GetRequestResolutions()
        {
            return await _context.RequestResolutions.ToListAsync();
        }
    }
}