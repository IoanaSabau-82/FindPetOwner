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
                CreatedById = request.CreatedById,
                Pictures = request.Pictures,
                Phone = request.Phone,
                Availability = request.Availability,
                Details = request.Details,
                Address = request.Address,
                Lat = request.Lat,
                Lng = request.Lng,
                PostStatus = request.PostStatus,
            };

            _repository.CreatePost(post);
            return Task.FromResult(post);
        }
    }
}
