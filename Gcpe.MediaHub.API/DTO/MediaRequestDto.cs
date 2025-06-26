using Gcpe.MediaHub.API.Models;

namespace Gcpe.MediaHub.API.DTO
{
    public class MediaRequestDto
    {
        public Guid Id { get; set; } = new Guid();
        public string RequestTitle { get; set; } = string.Empty;
        public DateTime ReceivedOn { get; set; } = new DateTime();
        public DateTime Deadline { get; set; } = new DateTime();
        public Ministry? LeadMinistry { get; set; } = new Ministry();
        public int RequestNo { get; set; }
    }
}
