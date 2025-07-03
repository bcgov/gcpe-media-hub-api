using System.ComponentModel.DataAnnotations;

namespace Gcpe.MediaHub.API.Models
{
    public class MediaContact
    {
        public Guid Id { get; set; }

        [MaxLength(100)]
        [Required(ErrorMessage = "Please enter a first name.")]
        public string FirstName { get; set; } = string.Empty;

        [MaxLength(100)]
        [Required(ErrorMessage = "Please enter a last name.")]
        public string LastName { get; set; } = string.Empty;

        public bool IsPressGallery { get; set; }

        [MaxLength(250)]
        [Url(ErrorMessage = "Please enter a valid website url.")]
        public string PersonalWebsite { get; set; } = string.Empty;
        public bool IsActive { get; set; }

        [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
        [MaxLength(100)]
        [Required(ErrorMessage = "Please enter an email address")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Select a job title.")]
        public int JobTitleId { get; set; }
        public JobTitle? JobTitle { get; set; }
        public ICollection<MediaOutletContactRelationship> MediaOutletContactRelationships { get; set; } = new List<MediaOutletContactRelationship>();
        public ICollection<MediaRequest> MediaRequests { get; set; } = new List<MediaRequest>();
        public ICollection<SocialMedia> SocialMedias { get; set; } = new List<SocialMedia>();
        public ICollection<PhoneNumber> PhoneNumbers { get; set; } = new List<PhoneNumber>();

        [MaxLength(50)]
        public string? Location { get; set; }

        public MediaContact(string firstName, string lastName, bool isPressGallery, string? personalWebsite, string email, int jobTitleId, string? location, bool isActive = true)
        {
            FirstName = firstName;
            LastName = lastName;
            IsPressGallery = isPressGallery;
            PersonalWebsite = personalWebsite;
            IsActive = isActive;
            Email = email;
            JobTitleId = jobTitleId;
            Location = location;
        }
        public MediaContact() { }
    }
}
