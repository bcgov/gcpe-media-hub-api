using System.ComponentModel.DataAnnotations;

namespace Gcpe.MediaHub.API.Models
{
    public class PersonalPhoneNumber
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public Guid ContactId {get;set;}
        [Required]
        public PhoneNumber? PhoneNumber { get; set;}
    }
}
