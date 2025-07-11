using Gcpe.MediaHub.API.Models;

namespace Gcpe.MediaHub.API.DTO
{
    public class ContactOutletDto
    {
        public string OutletName { get; set; } = "";
        public Guid OutletId { get; set; }
        public string OutletEmail { get; set; } = "";
      //  public List<string> ContactEmails { get; set; } = new();
        public List<MediaContactPhoneDto> ContactPhones { get; set; } = new();
        public bool IsMajorMedia { get; set; } = false;
        public string JobTitle { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;

        public string ContactEmail { get; set; } = string.Empty;
    }
}
