using System.ComponentModel.DataAnnotations;

namespace Gcpe.MediaHub.API.DTO
{
    public class CreateOrganizationDto
    {
        [Required]
        public string? OutletName { get; set; }
        [Required]
        public string? OrganizationType { get; set; }
        public bool IsMajorMedia { get; set; }
        public string? ParentOutletId { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Website { get; set; } = string.Empty;
        public List<int> MediaTypeIds { get; set; } = new List<int>();
        public List<int> WrittenLanguageIds { get; set; } = new List<int>();
        public List<PhoneNumberDto>? PhoneNumbers { get; set; }
        public List<SocialMediaLinkDto>? SocialMediaLinks { get; set; }
        public AddressDto? Address { get; set; }
    }

    public class PhoneNumberDto
    {
        public int TypeId { get; set; }
        public string? Number { get; set; }
    }

    public class SocialMediaLinkDto
    {
        public int TypeId { get; set; }
        public string? Url { get; set; }
    }

    public class AddressDto
    {
        public string? Street { get; set; }
        public string? City { get; set; }
        public string? Province { get; set; }
        public string? Country { get; set; }
        public string? PostalCode { get; set; }
    }
}

