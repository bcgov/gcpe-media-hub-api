namespace Gcpe.MediaHub.API.Models
{
    public class SocialMedia
    {
        public Guid Id { get; set; }

        public string Company { get; set; } = string.Empty;
        public string SocialProfileUrl { get; set; } = string.Empty;
        public int SocialMediaCompanyId { get; set; }

        public Guid? MediaOutletId { get; set; }
        public MediaOutlet? MediaOutlet { get; set; }

        public Guid? MediaContactId { get; set; }
        public MediaContact? MediaContact { get; set; }
    }
}
