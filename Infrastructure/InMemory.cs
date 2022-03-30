using Domain;
using FindPetOwner;
using System.Collections;

namespace Infrastructure
{
    public class InMemory
    {
        public static List<User> InMemoryUser = new ();
        public static List<FoundPetPost> InMemoryPost = new();
        public static List<AssignedVolunteer> InMemoryAssignedToPost = new();
    }
}