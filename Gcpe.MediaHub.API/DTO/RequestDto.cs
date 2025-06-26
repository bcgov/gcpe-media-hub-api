using Gcpe.MediaHub.API.Models;

namespace Gcpe.MediaHub.API.DTO
{
    public class RequestDto
    {
        public Guid Id { get; set; }
        public string RequestTitle { get; set; } = string.Empty;
        public DateTimeOffset ReceivedOn { get; set; } = DateTimeOffset.UtcNow;
        public DateTimeOffset Deadline { get; set; } = DateTimeOffset.UtcNow;
        public String LeadMinistryAbbr { get; set; } = string.Empty;
        public string RequestorContactFirstName { get; set; } = string.Empty;
        public string RequestorContactLastName { get; set; } = string.Empty;
        public int RequestNo { get; set; }
        public ICollection<String> AdditionalMinistriesAbbr { get; set; } = new List<string>();
        public string AssignedToFullName { get; set; } = string.Empty;
        public string RequestStatus { get; set; } = string.Empty;

    }
}
