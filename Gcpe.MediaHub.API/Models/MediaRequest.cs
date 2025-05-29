using System.ComponentModel.DataAnnotations;

namespace Gcpe.MediaHub.API.Models
{
    public class MediaRequest
    {
        public Guid Id { get; set; }
        
        [Required]
        public int? RequestStatusId { get; set; }
        public RequestStatus? RequestStatus { get; set; }

        [Required(ErrorMessage = "Please enter a short title.")]
        [MaxLength(100)]
        public string RequestTitle { get; set; } = string.Empty;

        [Required]
        public int? RequestTypeId { get; set; }
        public RequestType? RequestType { get; set; }

        [Required]
        [MaxLength(500)]
        public string RequestDetails { get; set; } = string.Empty;

        [Required]
        public Guid? RequestorContactId { get; set; }
        public MediaContact? RequestorContact { get; set; }
        public Guid? RequestorOutletId { get; set; }
        public MediaOutlet? RequestorOutlet { get; set; }
        public int? RequestResolutionId { get; set; }
        public RequestResolution? RequestResolution { get; set; }
        public int? LeadMinistryId { get; set; }
        public Ministry? LeadMinistry { get; set; }
        public ICollection<Ministry> AdditionalMinistries { get; set; } = new List<Ministry>();
        public Guid? AssignedUserId { get; set; }
        public User? AssignedUser { get; set; }

        [MaxLength(1000)]
        public string Response { get; set; } = string.Empty;
        public int RequestNo { get; set; }
        public DateTimeOffset ReceivedOn { get; set; } = DateTimeOffset.UtcNow;
        public DateTimeOffset Deadline { get; set; }
    }
}
