using Domain;
using System.ComponentModel.DataAnnotations;

namespace FindPetOwner
{
    public class User : BaseEntity
    {
        public Guid Id { get; set; }
        //[MaxLength(25)] lasat doar pt ca aa fost in tema, mutat pe fluent api
        public string FirstName { get ; set ; }
        //[MaxLength(25)]
        public string LastName { get ; set ; }
        //[MaxLength(50)]
        public string Email { get ; set ; }
        //[MaxLength(15)]
        public string Phone { get ; set ; }
        //[MaxLength(50)]
        public string Address { get ; set; }
        //pt tema
        public ICollection<FoundPetPost> FoundPetPosts { get; set; }
        public ICollection<AssignedVolunteer> AssignedVolunteers { get; set; }
        

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}
