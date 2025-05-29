namespace Gcpe.MediaHub.API.Models
{
    public class RequestStatus
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public ICollection<MediaRequest> MediaRequests { get; set; } = new List<MediaRequest>();
    }
}
