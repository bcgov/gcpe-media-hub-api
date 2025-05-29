namespace Gcpe.MediaHub.API.Models
{
    public class WrittenLanguage
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public ICollection<MediaOutlet> MediaOutlets { get; set; } = new List<MediaOutlet>();
    }
}
