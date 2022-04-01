using Domain;
using FindPetOwner;
using System.Collections;

namespace Infrastructure
{
    public class InMemory
    {
        public static List<User> User = new ();
        public static List<FoundPetPost> Post = new();
        public static List<AssignedVolunteer> AssignedToPost = new();
    }
}