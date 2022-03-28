using Domain;



namespace FindPetOwner
{
    public class RegularUser : IUser
    {
        public int Id { get; set ; }
        public string FirstName { get ; set ; }
        public string LastName { get ; set ; }
        public string Email { get ; set ; }
        public string Phone { get ; set ; }
        public string Address { get ; set; }

        public RegularUser(int id, string firstName, string lastName, string email, string phone="", string address="")
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Phone = phone;
            Address = address;
        }

        public IEnumerable<IPost> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IPost> GetById()
        {
            throw new NotImplementedException();
        }

        public void CreatePost()
        {
           .Add();
        }

        public void UpdatePost()
        {
            throw new NotImplementedException();
        }

        public void DeletePost()
        {
            throw new NotImplementedException();
        }
    }
}
