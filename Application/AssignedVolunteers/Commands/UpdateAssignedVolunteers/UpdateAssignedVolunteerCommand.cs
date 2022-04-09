using Domain;
using FindPetOwner;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.AssignedVolunteers.Commands.UpdateAssignedVolunteers
{
    public class UpdateAssignedVolunteerCommand: IRequest<AssignedVolunteer>
    {
        public User AssignedTo { get; set; }
        public FoundPetPost Post { get; set; }
        public DateTime ScheduledTime { get; set; }
        public AssignedStatus AssignedStatus { get; set; }

    }
}
