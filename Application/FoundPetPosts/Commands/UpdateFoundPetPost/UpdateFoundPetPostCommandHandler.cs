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

        public UpdateFoundPetPostCommandHandler(IFoundPetPostRepository repository)
        {
            _repository = repository;
        }

        public Task<FoundPetPost> Handle(UpdateFoundPetPostCommand request, CancellationToken cancellationToken)
        {
            var post = new FoundPetPost
            {
                CreatedBy = request.CreatedBy,
                Pictures = request.Pictures,
                Phone = request.Phone,
                Availability = request.Availability,
                Comment = request.Comment,
                Address = request.Address,
                GPScoordinates = request.GPScoordinates,
                PostStatus = request.PostStatus,
            };

            _repository.UpdatePost(post);

            return Task.FromResult(post);
        }
    }
}
