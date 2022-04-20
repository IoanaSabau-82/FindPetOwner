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
    public class GetAssignedVolunteerPostsQueryHandler: IRequestHandler<GetAssignedVolunteerPostsQuery,IEnumerable<AssignedVolunteer>>
    {
        private readonly IAssignedVolunteerRepository _repository;

        public GetAssignedVolunteerPostsQueryHandler(IAssignedVolunteerRepository repository)
        {
            _repository = repository;
        }

        public Task<IEnumerable<AssignedVolunteer>> Handle(GetAssignedVolunteerPostsQuery query, CancellationToken cancellationToken)
        {
            var result = _repository.GetAssignmentsToPosts(query.Id);
            return Task.FromResult(result);
        }
    }
}
