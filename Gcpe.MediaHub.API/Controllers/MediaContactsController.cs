using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Gcpe.MediaHub.API.Data;
using Gcpe.MediaHub.API.Models;
using System.Text.RegularExpressions;
using Gcpe.MediaHub.API.DTO;
using NuGet.Protocol;

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
        public async Task<ActionResult<IEnumerable<MediaContactDto>>> GetContact()
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
                        .ThenInclude(r => r.RequestStatus)
                    .Include(c => c.SocialMedias)
                    //.Include(c => c.PhoneNumbers)
                    .ToListAsync();

                var socialMedias = _context.SocialMedias;

                var result = contacts.Select(contact => new MediaContactDto
                {
                    Id = contact.Id,
                    FirstName = contact.FirstName,
                    LastName = contact.LastName,
                    Email = contact.Email,
                    IsActive = contact.IsActive,
                    JobTitle = contact.JobTitle?.Name ?? "",
                    PersonalWebsite = contact.PersonalWebsite,
                    IsPressGallery = contact.IsPressGallery,
                    //   PhoneNumbers = contact.PhoneNumbers,

                    MediaOutletContactRelationships = contact.MediaOutletContactRelationships.Select(rel => new ContactOutletDto
                    {
                        OutletName = rel.MediaOutlet.OutletName,
                        OutletId = rel.MediaOutlet.Id,
                        OutletEmail = rel.MediaOutlet.Email,
                        ContactEmail = rel.Emails.Select(e => e.EmailAddress).FirstOrDefault(),//.ToList(),
                        IsMajorMedia = rel.MediaOutlet.IsMajorMedia,
                        //ContactPhones = rel.PhoneNumbers, 

                    }).ToList(),
                    Requests = contact.MediaRequests.Select(rel => new MediaRequestDto
                    {
                        Id = rel.Id,
                        Title = rel.RequestTitle,
                        LeadMinistry = rel.LeadMinistry,
                        StatusId = (rel.RequestStatus != null)? rel.RequestStatus.Id : 0,
                        StatusName = (rel.RequestStatus != null) ? rel.RequestStatus.Name : string.Empty,
                        RequestNo = rel.RequestNo,
                        AdditionalMinistries = rel.AdditionalMinistries,
                    }).ToList(),
                    SocialMedias = contact.SocialMedias.Select(rel => new SocialMediaDto
                    {
                        CompanyId = rel.SocialMediaCompanyId,
                        Url = rel.SocialProfileUrl,
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
        public async Task<ActionResult<MediaContact>> PostContact(MediaContactDto contact)
        {
            try
            {
                // Todo: validation check to see if contact already exists.
                int jobTitleId = _context.JobTitles.FirstOrDefault()?.Id ?? 0; //TODO: talk to the team to get clarification on this 
                                                                               // First, create the new MediaContact so we can attach media relations, etc. to it.
                MediaContact newContact = new MediaContact(contact.FirstName,
                    contact.LastName,
                    contact.IsPressGallery,
                    contact.PersonalWebsite,
                    contact.Email,
                    jobTitleId,
                    null,
                    contact.IsActive
                    );

                _context.MediaContacts.Add(newContact);

                // lets do MediaOutletContactRelations now
                foreach (ContactOutletDto outletRelationship in contact.MediaOutletContactRelationships)
                {
                    MediaOutletContactRelationship relationship = new MediaOutletContactRelationship();
                    relationship.MediaOutletId = outletRelationship.OutletId;
                    relationship.MediaContactId = newContact.Id;
                    relationship.Title = contact.JobTitle;

                    _context.MediaOutletContactRelationship.Add(relationship); // need that id for what's next

                    //   foreach (string email in outletRelationship.ContactEmail)
                    _context.MediaContactEmails.Add(new MediaContactEmail
                    {
                        EmailAddress = outletRelationship.ContactEmail,
                        OutletContactRelationshipId = relationship.Id,
                        IsActive = true
                    });

                    int typeId = _context.MediaContactPhoneTypes.FirstOrDefault().Id;
                    _context.MediaContactPhone.Add(new MediaContactPhone
                    {
                        OutletContactRelationshipId = relationship.Id,
                        PhoneNumber = outletRelationship.PhoneNumber,
                        PhoneTypeId = typeId
                    });
                    foreach (MediaContactPhoneDto phone in outletRelationship.ContactPhones)
                    {  //Todo: Alex really should have another think about this bizarre null checking...
                        int typeId2 = _context.MediaContactPhoneTypes.FirstOrDefault(x => x.Name.ToLower() == phone.PhoneType.ToLower()).Id;
                        if (typeId2 > 0)
                            _context.MediaContactPhone.Add(new MediaContactPhone
                            {
                                OutletContactRelationshipId = relationship.Id,
                                PhoneNumber = phone.PhoneLineNumber,
                                PhoneTypeId = typeId2
                            });
                    }
                }

                foreach (SocialMediaDto social in contact.SocialMedias)
                {
                    if (social.CompanyId > 0)
                    {
                        _context.SocialMedias.Add(new SocialMedia
                        {
                            MediaContactId = newContact.Id,
                            SocialMediaCompanyId = social.CompanyId,
                            SocialProfileUrl = social.Url
                        });
                    }
                }

                await _context.SaveChangesAsync();

                return CreatedAtAction("GetContact", new { id = contact.Id }, contact);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
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

        [HttpGet("GetJobTitles")]
        public  IEnumerable<JobTitle> GetJobTitles()
        {
            return _context.JobTitles.ToList();
        }
        private bool ContactExists(Guid id)
        {
            return _context.MediaContacts.Any(e => e.Id == id);
        }

    }


    public class MediaContactDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string Email { get; set; } = "";
        public bool IsActive { get; set; }
        public string JobTitle { get; set; } = "";
        public bool IsPressGallery { get; set; } = false;
        public string? PersonalWebsite { get; set; } = string.Empty;
        // public List<PhoneNumberDto> PhoneNumbers { get; set; } = new();
        public List<ContactOutletDto> MediaOutletContactRelationships { get; set; } = new();
        public List<MediaRequestDto> Requests { get; set; } = new();
        public List<SocialMediaDto> SocialMedias { get; set; } = new();
    }


}
