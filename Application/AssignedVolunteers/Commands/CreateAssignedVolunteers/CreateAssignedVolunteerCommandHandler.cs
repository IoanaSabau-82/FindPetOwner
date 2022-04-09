using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Domain;

namespace Application.AssignedVolunteers.Commands.CreateAssignedVolunteers
{
    public class CreateAssignedVolunteerCommandHandler : IRequestHandler<CreateAssignedVolunteerCommand, AssignedVolunteer>
    {
        private readonly IAssignedVolunteerRepository _repository;

        public CreateAssignedVolunteerCommandHandler(IAssignedVolunteerRepository repository)
        {
            _repository = repository;
        }

        public Task<AssignedVolunteer> Handle(CreateAssignedVolunteerCommand request, CancellationToken cancellationToken)
        {
            var assigned = new AssignedVolunteer
            {
                AssignedTo = request.AssignedTo,
                Post = request.Post,
                ScheduledTime = request.ScheduledTime,
                AssignedStatus = request.AssignedStatus,
            };

            _repository.CreateAssigned(assigned);

            return Task.FromResult(assigned);
        }
    }
}
