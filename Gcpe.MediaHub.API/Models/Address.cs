namespace Gcpe.MediaHub.API.Models
{
    public class Address
    {
        public Guid Id { get; set; }
        public string ApartmentNumber { get; set; } = string.Empty;
        public string RuralRoute { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Municipality { get; set; } = string.Empty;
        public string StateProvince { get; set; } = string.Empty;

        public Guid MediaOutletId { get; set; }
        public MediaOutlet MediaOutlet { get; set; } = null!;
    }
}
