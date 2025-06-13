using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Gcpe.MediaHub.API.Data;
using Gcpe.MediaHub.API.Models;
namespace Gcpe.MediaHub.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MinistriesController : ControllerBase
    {
        private readonly GcpeMediaHubAPIContext _context;
        public MinistriesController(GcpeMediaHubAPIContext context)
        {
            _context = context;
        }

        // GET: api/Ministries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ministry>>> GetMinistries()
        {
            return await _context.Ministries.ToListAsync();
        }
    }
}