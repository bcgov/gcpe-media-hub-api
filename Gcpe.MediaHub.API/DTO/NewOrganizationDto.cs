using Gcpe.MediaHub.API.Models;

namespace Gcpe.MediaHub.API.DTO
{
    public class NewOrganizationDto
    {
        public IEnumerable<WrittenLanguage>? WrittenLanguages { get; set; }
        public IEnumerable<MediaType>? MediaTypes { get; set; }
        public IEnumerable<MediaOutletPhoneType>? PhoneTypes { get; set; }
        public IEnumerable<MediaOutlet>? MediaOutlets { get; set; }
        public IEnumerable<SocialMediaCompany>? SocialMediaTypes { get; set; }
    }
}
