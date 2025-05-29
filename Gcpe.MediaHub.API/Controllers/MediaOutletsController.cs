using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Gcpe.MediaHub.API.Data;
using Gcpe.MediaHub.API.Models;

namespace Gcpe.MediaHub.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MediaOutletsController : ControllerBase
    {
        private readonly GcpeMediaHubAPIContext _context;

        public MediaOutletsController(GcpeMediaHubAPIContext context)
        {
            _context = context;
        }

        // GET: api/MediaOutlets
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MediaOutlet>>> GetMediaOutlets()
        {
            return await _context.MediaOutlets.ToListAsync();
        }

        // GET: api/MediaOutlets/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MediaOutlet>> GetMediaOutlet(Guid id)
        {
            var mediaOutlet = await _context.MediaOutlets.FindAsync(id);

            if (mediaOutlet == null)
            {
                return NotFound();
            }

            return mediaOutlet;
        }

        // PUT: api/MediaOutlets/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMediaOutlet(Guid id, MediaOutlet mediaOutlet)
        {
            if (id != mediaOutlet.Id)
            {
                return BadRequest();
            }

            _context.Entry(mediaOutlet).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MediaOutletExists(id))
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

        // POST: api/MediaOutlets
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MediaOutlet>> PostMediaOutlet(MediaOutlet mediaOutlet)
        {
            _context.MediaOutlets.Add(mediaOutlet);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMediaOutlet", new { id = mediaOutlet.Id }, mediaOutlet);
        }

        // DELETE: api/MediaOutlets/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMediaOutlet(Guid id)
        {
            var mediaOutlet = await _context.MediaOutlets.FindAsync(id);
            if (mediaOutlet == null)
            {
                return NotFound();
            }

            _context.MediaOutlets.Remove(mediaOutlet);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MediaOutletExists(Guid id)
        {
            return _context.MediaOutlets.Any(e => e.Id == id);
        }
    }
}
