using FindPetOwner;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace Application.AssignedVolunteers.Queries
{
    public class GetAssignedVolunteerPostQuery:IRequest<AssignedVolunteer>
    {
        public Guid Id { get; set; }
    }
}
