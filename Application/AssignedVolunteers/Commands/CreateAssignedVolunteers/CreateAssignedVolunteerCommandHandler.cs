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
        private readonly IFoundPetPostRepository _postRepository;

        public CreateAssignedVolunteerCommandHandler(IAssignedVolunteerRepository repository, IFoundPetPostRepository postRepository)
        {
            _repository = repository;
            _postRepository = postRepository;
        }

        public Task<AssignedVolunteer> Handle(CreateAssignedVolunteerCommand request, CancellationToken cancellationToken)
        {
            var assigned = new AssignedVolunteer
            {
                AssignedToId = request.AssignedToId,
                PostId = request.PostId,
                ScheduledTime = request.ScheduledTime,
                AssignedStatus = request.AssignedStatus,
            };

            var post = _postRepository.GetPost(request.PostId);

            if (post.PostStatus != PostStatus.Open)
                throw new Exception("can't have two assignments for the same post");

            _repository.CreateAssigned(assigned);
            _postRepository.UpdatePostStatus(request.PostId, 1);

            return Task.FromResult(assigned);
        }
    }
}
