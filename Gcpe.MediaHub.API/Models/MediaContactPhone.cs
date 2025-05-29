namespace Gcpe.MediaHub.API.Models
{
    public class MediaContactPhone
    {
        public Guid Id { get; set; }
        public Guid OutletContactRelationshipId { get; set; }
        public MediaOutletContactRelationship OutletContactRelationship { get; set; } = null!;
        public string PhoneNumber { get; set; } = string.Empty;
        public string? Extension { get; set; }
        public int PhoneTypeId { get; set; }
        public MediaContactPhoneType? PhoneType { get; set; }
        public bool IsActive { get; set; }
    }
}
