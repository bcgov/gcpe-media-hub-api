namespace Gcpe.MediaHub.API.Models
{
    public class MediaOutletPhoneNumber
    {
        public Guid Id { get; set; }
        public MediaOutletPhoneType? MediaOutletPhoneType { get; set; }
        public string PhoneNumber { get; set; } = string.Empty;
        public Guid? MediaOutletId { get; set; }
        public MediaOutlet? MediaOutlet { get; set; }
    }
}
