using Domain;
using FindPetOwner;

namespace Api.Dtos
{
    public class AssignedVolunteerByUserGetDto
    {
        public Guid Id { get; set; }
        public FoundPetPost Post { get; set; }
        public DateTime ScheduledTime { get; set; }
        public AssignedStatus AssignedStatus { get; set; }
    }
}
