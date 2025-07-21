using Gcpe.MediaHub.API.Models;

namespace Gcpe.MediaHub.API.DTO
{
    public class MediaRequestDto
    {
        public Guid Id { get; set; } = new Guid();
        public string Title { get; set; } = string.Empty;
        public DateTime ReceivedOn { get; set; } = new DateTime();
        public DateTime Deadline { get; set; } = new DateTime();
        public Ministry? LeadMinistry { get; set; } = new Ministry();
        public int StatusId { get; set; }
        public string? StatusName { get; set; } = string.Empty;
        public int RequestNo { get; set; }
    }
}
