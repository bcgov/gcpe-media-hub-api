using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Gcpe.MediaHub.API.Data;
using Gcpe.MediaHub.API.Models;
using System.Text.RegularExpressions;
using Gcpe.MediaHub.API.DTO;

namespace Gcpe.MediaHub.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MediaContactsController : ControllerBase
    {
        private readonly GcpeMediaHubAPIContext _context;

        public MediaContactsController(GcpeMediaHubAPIContext context)
        {
            _context = context;
        }

        // GET: api/Contacts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ContactDto>>> GetContact()
        {
            try
            {
                var contacts = await _context.MediaContacts
                    .Include(c => c.JobTitle)
                    .Include(c => c.MediaOutletContactRelationships)
                        .ThenInclude(rel => rel.MediaOutlet)
                    .Include(c => c.MediaOutletContactRelationships)
                        .ThenInclude(rel => rel.Emails)
                    .Include(c => c.MediaOutletContactRelationships)
                        .ThenInclude(rel => rel.PhoneNumbers)
                    .Include(c => c.MediaRequests)
                    .ToListAsync();

                var result = contacts.Select(contact => new ContactDto
                {
                    Id = contact.Id,
                    FirstName = contact.FirstName,
                    LastName = contact.LastName,
                    Email = contact.Email,
                    IsActive = contact.IsActive,
                    JobTitle = contact.JobTitle?.Name ?? "",

                    Outlets = contact.MediaOutletContactRelationships.Select(rel => new ContactOutletDto
                    {
                        OutletName = rel.MediaOutlet.OutletName,
                        OutletEmail = rel.MediaOutlet.Email,
                        ContactEmails = rel.Emails.Select(e => e.EmailAddress).ToList(),
                        ContactPhones = rel.PhoneNumbers
                            .Select(p => string.IsNullOrWhiteSpace(p.Extension)
                                ? p.PhoneNumber
                                : $"{p.PhoneNumber} ext. {p.Extension}")
                            .ToList()
                    }).ToList(),
                    Requests = contact.MediaRequests.Select(rel => new MediaRequestDto
                    {
                        RequestTitle = rel.RequestTitle,
                        LeadMinistry = rel.LeadMinistry,
                    }).ToList(),
                }).ToList();

                return result;
            }
            catch (Exception ex)
            {
                return null;
            }

        }


        // GET: api/Contacts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MediaContact>> GetContact(Guid id)
        {
            var contact = await _context.MediaContacts
                .Include(c => c.MediaOutletContactRelationships)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (contact == null)
            {
                return NotFound();
            }

            return contact;
        }

        // GET: api/MediaContacts/search/{fullName}
        [HttpGet("search/{fullName}")]
        public async Task<ActionResult<MediaContact>> GetMediaContactByFullName(string fullName)
        {
            try
            {
                // Remove extra spaces and split the name
                var cleanName = Regex.Replace(fullName?.Trim() ?? "", @"\s+", " ");
                var nameParts = cleanName.Split(' ');

                if (string.IsNullOrEmpty(cleanName) || nameParts.Length != 2)
                {
                    return BadRequest("Full name must be in 'FirstName LastName' format");
                }

                var firstName = nameParts[0];
                var lastName = nameParts[1];

                // Get all active contacts and filter in memory
                var allContacts = await _context.MediaContacts
                    .Include(c => c.JobTitle)
                    .Where(c => c.IsActive)
                    .ToListAsync();

                var contact = allContacts.FirstOrDefault(c =>
                    c.FirstName.Equals(firstName, StringComparison.OrdinalIgnoreCase) &&
                    c.LastName.Equals(lastName, StringComparison.OrdinalIgnoreCase));

                if (contact == null)
                {
                    return NotFound($"No active contact found with name '{fullName}'");
                }

                return contact;
            }
            catch (Exception ex)
            {
                var error = $"Error searching for contact '{fullName}': {ex.Message}";
                Console.Error.WriteLine(error);
                Console.Error.WriteLine(ex.StackTrace);
                return StatusCode(500, error);
            }
        }

        // PUT: api/Contacts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutContact(Guid id, MediaContact contact)
        {
            if (id != contact.Id)
            {
                return BadRequest();
            }

            _context.Entry(contact).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContactExists(id))
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

        // POST: api/Contacts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MediaContact>> PostContact(MediaContact contact)
        {
            _context.MediaContacts.Add(contact);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetContact", new { id = contact.Id }, contact);
        }

        // DELETE: api/Contacts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContact(Guid id)
        {
            var contact = await _context.MediaContacts.FindAsync(id);
            if (contact == null)
            {
                return NotFound();
            }

            _context.MediaContacts.Remove(contact);
            await _context.SaveChangesAsync();

            return NoContent();
        }


        [HttpGet("GetSocialMedias")]
        public async Task<ActionResult<IEnumerable<SocialMediaCompanyDto>>> GetSocialMedias()
        {
            var companies = await _context.SocialMediaCompanies.ToListAsync();

            var result = companies.Select(company => new SocialMediaCompanyDto
            {
                Id = company.Id,
                Company = company.Name,
            }).ToList();

            return result;
        }

        private bool ContactExists(Guid id)
        {
            return _context.MediaContacts.Any(e => e.Id == id);
        }

    }

    public class ContactDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string Email { get; set; } = "";
        public bool IsActive { get; set; }
        public string JobTitle { get; set; } = "";

        public List<ContactOutletDto> Outlets { get; set; } = new();
        public List<MediaRequestDto> Requests { get; set; } = new();
    }


}
