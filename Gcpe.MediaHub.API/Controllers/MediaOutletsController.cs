using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Gcpe.MediaHub.API.Data;
using Gcpe.MediaHub.API.Models;
using Gcpe.MediaHub.API.DTO;

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
        public async Task<ActionResult<IEnumerable<OrganizationListDto>>> GetMediaOutlets()
        {
            return await _context.MediaOutlets
                            .Include(m => m.MediaOutletPhoneNumbers)
                            .Include(m => m.MediaTypes)
                            .Include(m => m.Addresses)
                            .Select(m => new OrganizationListDto
                            {
                                Id = m.Id,
                                Name = m.OutletName,
                                IsMajorMedia = m.IsMajorMedia,
                                Email = m.Email,
                                PhoneNumber = m.MediaOutletPhoneNumbers.FirstOrDefault().PhoneNumber ?? string.Empty,
                                MediaTypes = m.MediaTypes.Select(mt => mt.Name).ToList(),
                                City = m.Addresses.FirstOrDefault().City ?? string.Empty,
                                ParentId = m.ParentOutletId,
                            })
                            .ToListAsync();
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
        [HttpPost]
        public async Task<ActionResult<MediaOutlet>> PostMediaOutlet([FromBody] CreateOrganizationDto createDto)
        {
            if (!string.IsNullOrWhiteSpace(createDto.ParentOutletId))
            {
                var parentNetwork = await _context.MediaOutlets.FirstOrDefaultAsync(o => o.Id == Guid.Parse(createDto.ParentOutletId));

                if (parentNetwork == null)
                {
                    return NotFound("Parent network not found.");
                }
            }

            var org = new MediaOutlet();
            org.OutletName = createDto.OutletName ?? "";
            org.IsMajorMedia = createDto.IsMajorMedia;
            org.Email = createDto.Email;
            org.Website = createDto.Website;

            if(!string.IsNullOrWhiteSpace(createDto.ParentOutletId)) org.ParentOutletId = Guid.Parse(createDto.ParentOutletId);

            _context.Add(org);
            _context.SaveChanges();

            if (createDto.Address != null)
            {
                org.Addresses.Add(new Address
                {
                    Street = createDto.Address.Street,
                    City = createDto.Address.City!,
                    Province = createDto.Address.Province,
                    Country = createDto.Address.Country,
                    PostalCode = createDto.Address.PostalCode,
                    MediaOutletId = org.Id
                }
                );
            }

            if (createDto.MediaTypeIds?.Count != 0)
            {
                foreach (var mediaTypeId in createDto.MediaTypeIds!)
                {
                    var dbMediaType = _context.MediaTypes.FirstOrDefault(mt => mt.Id == mediaTypeId);
                    if (dbMediaType != null)
                    {
                        org.MediaTypes.Add(dbMediaType);
                    }
                }
            }

            if (createDto.WrittenLanguageIds?.Count != 0)
            {
                foreach (var langId in createDto.WrittenLanguageIds!)
                {
                    var dbLang = _context.WrittenLanguages.FirstOrDefault(l => l.Id == langId);
                    if (dbLang != null)
                    {
                        org.WrittenLanguages.Add(dbLang);
                    }
                }
            }

            if (createDto.SocialMediaLinks?.Count != 0)
            {
                foreach (var socialLink in createDto.SocialMediaLinks!)
                {
                    org.SocialMedias.Add(
                        new SocialMedia
                        {
                            SocialMediaCompanyId = socialLink.TypeId,
                            SocialProfileUrl = socialLink.Url!,
                            MediaOutletId = org.Id
                        });
                }
            }

            if (createDto.PhoneNumbers?.Count != 0)
            {
                foreach (var phoneNumber in createDto.PhoneNumbers!)
                {
                    var phoneType = _context.MediaOutletPhoneTypes.FirstOrDefault(pt => pt.Id == phoneNumber.TypeId);

                    org.MediaOutletPhoneNumbers.Add(
                        new MediaOutletPhoneNumber
                        {
                            MediaOutletId = org.Id,
                            MediaOutletPhoneType = phoneType,
                            PhoneNumber = phoneNumber.Number!
                        });
                }
            }

            await _context.SaveChangesAsync();
            return Created();
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

        // GET: api/mediaoutlets/dropdowns
        [HttpGet("dropdowns")]
        public async Task<IActionResult> GetDropDowns()
        {
            var rvl = new NewOrganizationDto
            {
                WrittenLanguages = await _context.WrittenLanguages.ToListAsync(),
                MediaTypes = await _context.MediaTypes.ToListAsync(),
                PhoneTypes = await _context.MediaOutletPhoneTypes.ToListAsync(),
                MediaOutlets = await _context.MediaOutlets.Where(o => o.ParentOutletId == null).ToListAsync(),
                SocialMediaTypes = await _context.SocialMediaCompanies.ToListAsync(),
            };

            return Ok(rvl);
        }
    }


}
