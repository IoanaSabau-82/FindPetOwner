using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FindPetOwner;
using MediatR;
using Domain;

namespace Application.AssignedVolunteers.Queries
{
    public class GetAssignedVolunteerPostQueryHandler: IRequestHandler<GetAssignedVolunteerPostQuery,AssignedVolunteer>
    {
        private readonly IAssignedVolunteerRepository _repository;

        public GetAssignedVolunteerPostQueryHandler(IAssignedVolunteerRepository repository)
        {
            _repository = repository;
        }

        public Task<AssignedVolunteer> Handle(GetAssignedVolunteerPostQuery query, CancellationToken cancellationToken)
        {
            var result = _repository.GetAssignment(query.Id);
            return Task.FromResult(result);
        }
    }
}
