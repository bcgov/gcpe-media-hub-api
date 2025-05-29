namespace Gcpe.MediaHub.API.Models
{
    public class SocialMediaCompany
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public ICollection<SocialMedia> SocialMedias { get; set; } = new List<SocialMedia>();
    }
}
