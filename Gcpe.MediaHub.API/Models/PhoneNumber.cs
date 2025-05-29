using System.ComponentModel.DataAnnotations;

namespace Gcpe.MediaHub.API.Models
{
    public class PhoneNumber
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Please select a Phone Type")]
        public string PhoneType { get; set; } = string.Empty;
        public string CountryCode { get; set; } = string.Empty;
        public int PhoneLineNumber { get; set; }
        public int? PhoneExtension { get; set; }

        public ICollection<MediaOutlet> MediaOutlets { get; set; } = new List<MediaOutlet>();
    }
}
