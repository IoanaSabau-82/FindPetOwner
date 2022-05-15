using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Domain;

namespace Application.FoundPetPosts.Commands.UpdateFoundPetPost
{
    public class UpdateFoundPetPostCommandHandler : IRequestHandler<UpdateFoundPetPostCommand, FoundPetPost>
    {
        private readonly IFoundPetPostRepository _repository;
        private readonly IUserRepository _userRepository;

        public UpdateFoundPetPostCommandHandler(IFoundPetPostRepository repository, IUserRepository userRepository)
        {
            _repository = repository;
            _userRepository = userRepository;
        }

        public Task<FoundPetPost> Handle(UpdateFoundPetPostCommand request, CancellationToken cancellationToken)
        {
            var post = new FoundPetPost
            {
                Id = request.Id,
                CreatedBy = _userRepository.GetUser(request.CreatedById),
                //Pictures = request.Pictures,
                Phone = request.Phone,
                Availability = request.Availability,
                Details = request.Details,
                Address = request.Address,
                Latitude = request.Latitude,
                Longitude = request.Longitude,
                PostStatus = request.PostStatus,
            };

            _repository.UpdatePost(post);

            return Task.FromResult(post);
        }
    }
}
