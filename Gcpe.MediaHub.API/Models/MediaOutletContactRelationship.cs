namespace Gcpe.MediaHub.API.Models
{
    public class MediaOutletContactRelationship
    {
        public Guid Id { get; set; }
        public Guid MediaOutletId { get; set; }
        public MediaOutlet MediaOutlet { get; set; } = null!;
        public Guid MediaContactId { get; set; }
        public MediaContact MediaContact { get; set; } = null!;
        public string Title { get; set; } = string.Empty;
        public DateTimeOffset StartDate { get; set; } = DateTimeOffset.UtcNow;
        public DateTimeOffset? EndDate { get; set; }
        public List<MediaContactEmail> Emails { get; set; } = new();
        public List<MediaContactPhone> PhoneNumbers { get; set; } = new();
    }

}
