using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Gcpe.MediaHub.API.Data;
using Gcpe.MediaHub.API.Models;

namespace Gcpe.MediaHub.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MediaRequestsController : ControllerBase
    {
        private readonly GcpeMediaHubAPIContext _context;

        public MediaRequestsController(GcpeMediaHubAPIContext context)
        {
            _context = context;
        }

        // GET: api/MediaRequests
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MediaRequest>>> GetMediaRequests()
        {
            return await _context.
                MediaRequests
                    .Include(c => c.RequestorContact)
                    .Include(m => m.LeadMinistry)
                    .Include(o => o.RequestorOutlet)
                    .Include(s => s.RequestStatus)
                    .Include(t => t.RequestType)
                    .Include(r => r.RequestResolution)
                    .Include(c => c.AssignedUser)
                        .ToListAsync();
        }

        // GET: api/MediaRequests/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MediaRequest>> GetMediaRequest(Guid id)
        {
            var mediaRequest = await _context.MediaRequests
                .Include(c => c.RequestorContact)
                .Include(m => m.LeadMinistry)
                .Include(o => o.RequestorOutlet)
                .Include(s => s.RequestStatus)
                .Include(t => t.RequestType)
                .Include(r => r.RequestResolution)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (mediaRequest == null)
            {
                return NotFound();
            }

            return mediaRequest;
        }

        // PUT: api/MediaRequests/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMediaRequest(Guid id, MediaRequest mediaRequest)
        {
            if (id != mediaRequest.Id)
            {
                return BadRequest();
            }

            _context.Entry(mediaRequest).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MediaRequestExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/MediaRequests
        [HttpPost]
        public async Task<ActionResult<MediaRequest>> PostMediaRequest(MediaRequest mediaRequest)
        {
            _context.MediaRequests.Add(mediaRequest);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMediaRequest", new { id = mediaRequest.Id }, mediaRequest);
        }

        // DELETE: api/MediaRequests/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMediaRequest(Guid id)
        {
            var mediaRequest = await _context.MediaRequests.FindAsync(id);
            if (mediaRequest == null)
            {
                return NotFound();
            }

            _context.MediaRequests.Remove(mediaRequest);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MediaRequestExists(Guid id)
        {
            return _context.MediaRequests.Any(e => e.Id == id);
        }
    }
}
