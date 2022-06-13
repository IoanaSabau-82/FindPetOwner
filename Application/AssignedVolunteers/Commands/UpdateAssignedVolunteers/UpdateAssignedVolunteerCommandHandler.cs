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
        private readonly IUserRepository _userRepository;
        private readonly IFoundPetPostRepository _postRepository;


        public UpdateAssignedVolunteerCommandHandler(IAssignedVolunteerRepository repository,
            IUserRepository userRepository, IFoundPetPostRepository postRepository)
        {
            _repository = repository;
            _userRepository = userRepository;
            _postRepository = postRepository;
        }

        public Task<AssignedVolunteer> Handle(UpdateAssignedVolunteerCommand request, CancellationToken cancellationToken)
        {
            var assigned = new AssignedVolunteer
            {
                Id = request.Id,
                AssignedToId = request.AssignedToId,
                PostId = request.PostId,
                ScheduledTime = request.ScheduledTime,
                AssignedStatus = request.AssignedStatus,
            };

            _repository.UpdateAssigned(assigned);

            return Task.FromResult(assigned);
        }
    }
}
