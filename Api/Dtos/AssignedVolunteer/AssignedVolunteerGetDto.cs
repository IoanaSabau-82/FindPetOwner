using Domain;
using FindPetOwner;

namespace Api.Dtos
{
    public class AssignedVolunteerGetDto
    {
        public Guid Id { get; set; }
        public FoundPetPostGetDto Post { get; set; }
        public DateTime ScheduledTime { get; set; }
        public AssignedStatus AssignedStatus { get; set; }
    }
}
