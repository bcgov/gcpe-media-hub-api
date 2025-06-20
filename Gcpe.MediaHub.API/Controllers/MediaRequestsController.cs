using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Gcpe.MediaHub.API.Data;
using Gcpe.MediaHub.API.Models;
using Microsoft.Extensions.Logging;

namespace Gcpe.MediaHub.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MediaRequestsController : ControllerBase
    {
        private readonly GcpeMediaHubAPIContext _context;
        private readonly ILogger<MediaRequestsController> _logger;

        public MediaRequestsController(GcpeMediaHubAPIContext context, ILogger<MediaRequestsController> logger)
        {
            _context = context;
            _logger = logger;
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
                    .Include(f => f.FYIContactUser)
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
        public async Task<IActionResult> PostMediaRequest(MediaRequest mediaRequest)
        {
            try
            {
                // Validate the incoming request
                if (mediaRequest == null)
                {
                    return BadRequest("MediaRequest cannot be null.");
                }

                // Ensure lead ministry is valid
                var leadMinistry = await _context.Ministries.FindAsync(mediaRequest.LeadMinistryId);
                if (leadMinistry == null)
                {
                    return BadRequest($"Lead ministry with ID {mediaRequest.LeadMinistryId} does not exist.");
                }
                mediaRequest.LeadMinistry = leadMinistry;

                // Handle additional ministries
                var additionalMinistryIds = mediaRequest.AdditionalMinistries.Select(m => m.Id).ToList();
                var existingMinistries = await _context.Ministries
                    .Where(m => additionalMinistryIds.Contains(m.Id))
                    .ToListAsync();

                if (existingMinistries.Count != additionalMinistryIds.Count)
                {
                    return BadRequest("One or more additional ministries do not exist.");
                }

                mediaRequest.AdditionalMinistries = existingMinistries;

                // Add the media request to the database
                _context.MediaRequests.Add(mediaRequest);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetMediaRequest", new { id = mediaRequest.Id }, mediaRequest);
            }
            catch (Exception ex)
            {
                // Log the exception and return an error response
                _logger.LogError(ex, "Error occurred while creating media request.");
                return StatusCode(500, "An error occurred while processing your request.");
            }
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
