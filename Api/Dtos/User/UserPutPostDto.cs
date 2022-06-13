using Domain;
using System.ComponentModel.DataAnnotations;

namespace Api.Dtos
{
    public class UserPutPostDto
    {   [Required]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Only letters allowed in the first name")]
        [MaxLength(25)]
        [MinLength(3)]
        public string FirstName { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Only letters allowed in the first name")]
        [MaxLength(25)]
        [MinLength(3)]
        public string LastName { get; set; }


        [Required]
        [EmailAddress]
        [MaxLength(50)]
        public string Email { get; set; }

        [Required]
        [Phone]
        [MaxLength(15)]
        public string Phone { get; set; }

        [Required]
        [MaxLength(50)]
        public string Address { get; set; }

    }
}
