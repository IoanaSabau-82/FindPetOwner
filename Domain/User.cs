using Domain;
using System.ComponentModel.DataAnnotations;

namespace FindPetOwner
{
    public class User : BaseEntity
    {
        public Guid Id { get; set; }
        [MaxLength(25)]
        public string FirstName { get ; set ; }
        [MaxLength(25)]
        public string LastName { get ; set ; }
        [MaxLength(50)]
        public string Email { get ; set ; }
        [MaxLength(15)]
        public string Phone { get ; set ; }
        [MaxLength(50)]
        public string Address { get ; set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}
