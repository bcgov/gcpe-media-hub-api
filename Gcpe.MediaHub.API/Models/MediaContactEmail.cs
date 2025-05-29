namespace Gcpe.MediaHub.API.Models
{
    public class MediaContactEmail
    {
        public Guid Id { get; set; }
        public Guid OutletContactRelationshipId { get; set; }
        public MediaOutletContactRelationship OutletContactRelationship { get; set; } = null!;
        public string EmailAddress { get; set; } = string.Empty;
        public bool IsPrimary { get; set; }
        public bool IsActive { get; set; }
    }

}
