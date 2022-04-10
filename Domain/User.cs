using Domain;



namespace FindPetOwner
{
    public class User : BaseEntity
    {
        public Guid Id { get; set; }
        public string FirstName { get ; set ; }
        public string LastName { get ; set ; }
        public string Email { get ; set ; }
        public string Phone { get ; set ; }
        public string Address { get ; set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}
