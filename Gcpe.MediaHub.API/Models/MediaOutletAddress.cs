namespace Gcpe.MediaHub.API.Models
{
    public class MediaOutletAddress
    {
        public Guid Id { get; set; }
        public Guid MediaOutletId { get; set; }
        public Address Address { get; set; } = null!;
    }
}
