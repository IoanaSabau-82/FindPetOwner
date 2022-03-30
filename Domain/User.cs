using Domain;



namespace FindPetOwner
{
    public class User
    {
        public Guid Id { get; set; }
        public string FirstName { get ; set ; }
        public string LastName { get ; set ; }
        public string Email { get ; set ; }
        public string Phone { get ; set ; }
        public string Address { get ; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}
