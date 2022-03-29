using Domain;
using FindPetOwner;
using System.Collections;

namespace Infrastructure
{
    public class InMemory
    {
        public static List<User> InMemoryUser { get; set; }
        public static List<FoundPetPost> InMemoryPost { get; set; }
        public static List<AssignVolunteer> InMemoryAssignedToPost { get; set; }
    }
}