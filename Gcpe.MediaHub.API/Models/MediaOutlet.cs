using System.ComponentModel.DataAnnotations;

namespace Gcpe.MediaHub.API.Models
{
    public class MediaOutlet
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Please enter an outlet name.")]
        [MaxLength(250)]
        public string OutletName { get; set; } = string.Empty;
        public bool IsMajorMedia { get; set; }

        [Required(ErrorMessage = "Please enter an email address.")]
        [MaxLength(100)]
        public string Email { get; set; } = string.Empty;

        [Url(ErrorMessage = "Please enter a valid URL")]
        public string Website { get; set; } = string.Empty;
        public PhoneNumber? PhoneNumber { get; set; }
        public ICollection<Address> Addresses { get; set; } = new List<Address>();
        public ICollection<MediaType> MediaTypes { get; set; } = new List<MediaType>();
        public ICollection<WrittenLanguage> WrittenLanguages { get; set; } = new List<WrittenLanguage>();
        public ICollection<SocialMedia> SocialMedias { get; set; } = new List<SocialMedia>();
        public ICollection<MediaRequest> MediaRequests { get; set; } = new List<MediaRequest>();

    }
}
