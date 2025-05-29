namespace Gcpe.MediaHub.API.Models
{
    public class JobTitle
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public ICollection<MediaContact> MediaContacts { get; set; } = new List<MediaContact>();
    }
}
