namespace Gcpe.MediaHub.API.Models
{
    public class Ministry
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Acronym { get; set; } = string.Empty;

        // TODO: revisit
        public ICollection<MediaRequest> LeadMediaRequests { get; set; } = new List<MediaRequest>();
        public ICollection<MediaRequest> AdditionalMediaRequests { get; set; } = new List<MediaRequest>(); // TODO: revisit
    }

}
