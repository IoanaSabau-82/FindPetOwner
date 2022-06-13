using Domain;
using FindPetOwner;

namespace Api.Dtos
{
    public class AssignedVolunteerPutPostDto
    {
        public UserIdDto AssignedTo { get; set; }
        public PostIdDto Post { get; set; }
        public DateTime ScheduledTime { get; set; }
        public AssignedStatus AssignedStatus { get; set; }
    }
}
