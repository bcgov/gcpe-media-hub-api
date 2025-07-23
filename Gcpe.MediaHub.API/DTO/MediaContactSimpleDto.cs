namespace Gcpe.MediaHub.API.DTO
{
    public class MediaContactSimpleDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string JobTitle { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
    }
}
