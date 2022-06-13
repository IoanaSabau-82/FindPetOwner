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
        public Guid Id { get; set; }
        public Guid AssignedToId { get; set; }
        public Guid PostId { get; set; }
        public DateTime ScheduledTime { get; set; }
        public AssignedStatus AssignedStatus { get; set; }

    }
}
