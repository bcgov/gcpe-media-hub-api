using Gcpe.MediaHub.API.Models;

namespace Gcpe.MediaHub.API.DTO
{
    public class OrganizationListDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public bool IsMajorMedia { get; set; }
        public List<string> MediaTypes { get; set; } = new List<string>();
        public string City { get; set; } = string.Empty;

        public Guid? ParentId { get; set; }
    }
}
