using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Domain;

namespace Application.FoundPetPosts.Commands.CreateFoundPetPost
{
    public class CreateFoundPetPostCommandHandler : IRequestHandler<CreateFoundPetPostCommand, FoundPetPost>
    {
        private readonly IFoundPetPostRepository _repository;

        public CreateFoundPetPostCommandHandler(IFoundPetPostRepository repository)
        {
            _repository = repository;
        }

        public Task<FoundPetPost> Handle(CreateFoundPetPostCommand request, CancellationToken cancellationToken)
        {
            var post = new FoundPetPost
            {
                CreatedBy = request.CreatedBy,
                Picture = request.Picture,
                Phone = request.Phone,
                AvailabilityStart = request.AvailabilityStart,
                AvailabilityEnd = request.AvailabilityEnd,
                Comment = request.Comment,
                Address = request.Address,
                Latitude = request.Latitude,
                Longitude = request.Longitude,
                PostStatus = request.PostStatus,
            };

            _repository.CreatePost(post);

            return Task.FromResult(post);
        }
    }
}
