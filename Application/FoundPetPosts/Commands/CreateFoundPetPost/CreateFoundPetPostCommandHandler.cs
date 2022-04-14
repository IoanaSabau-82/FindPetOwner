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

            //var pictures = request.Pictures.Select(pictureDto => new Picture(pictureDto.Name, pictureDto.FilePath)); pt asta ar treb sa existe deja in db
            //ar trebui sa am in repository FoundpetPost o metoda de add pictures? care sa reprezinte salvarea in bd?
            //dar cum face legatura cu post inainte de a salva?
           
            var post = new FoundPetPost
            {
                //CreatedBy = request.CreatedBy,
                //Pictures = request.Pictures,
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
