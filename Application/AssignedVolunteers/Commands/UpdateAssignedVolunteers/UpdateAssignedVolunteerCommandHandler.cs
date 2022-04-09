using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Domain;

namespace Application.AssignedVolunteers.Commands.UpdateAssignedVolunteers
{
    public class UpdateAssignedVolunteerCommandHandler : IRequestHandler<UpdateAssignedVolunteerCommand, AssignedVolunteer>
    {
        private readonly IAssignedVolunteerRepository _repository;

        public UpdateAssignedVolunteerCommandHandler(IAssignedVolunteerRepository repository)
        {
            _repository = repository;
        }

        public Task<AssignedVolunteer> Handle(UpdateAssignedVolunteerCommand request, CancellationToken cancellationToken)
        {
            var assigned = new AssignedVolunteer
            {
                AssignedTo = request.AssignedTo,
                Post = request.Post,
                ScheduledTime = request.ScheduledTime,
                AssignedStatus = request.AssignedStatus,
            };

            _repository.UpdateAssigned(assigned);

            return Task.FromResult(assigned);
        }
    }
}
