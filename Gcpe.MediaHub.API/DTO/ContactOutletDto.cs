namespace Gcpe.MediaHub.API.DTO
{
    public class ContactOutletDto
    {
        public string OutletName { get; set; } = "";
        public string OutletEmail { get; set; } = "";
        public List<string> ContactEmails { get; set; } = new();
        public List<string> ContactPhones { get; set; } = new();
        public bool IsMajorMedia { get; set; } = false;
    }
}
