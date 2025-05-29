namespace Gcpe.MediaHub.API.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string IDIR { get; set; } = string.Empty;
        public ICollection<MediaRequest> MediaRequests { get; set; } = new List<MediaRequest>();
    }
}
