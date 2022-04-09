using Domain;
using FindPetOwner;
using System.Collections;

namespace Infrastructure
{
    public class InMemory
    {
        public static List<User> User = new()
        {
            new User()
            {
                Id = Guid.NewGuid(),
                FirstName = "jane",
                LastName = "doe"
            }

        };
        public static List<FoundPetPost> Post = new();
        public static List<AssignedVolunteer> AssignedToPost = new();
    }
}