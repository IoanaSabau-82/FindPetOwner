using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Domain;

namespace Application.FoundPetPosts.Commands.DeleteFoundPetPost
{
    public class DeleteFoundPetPostCommandHandler : IRequestHandler<DeleteFoundPetPostCommand>
    {
        private readonly IFoundPetPostRepository _repository;

        public DeleteFoundPetPostCommandHandler(IFoundPetPostRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteFoundPetPostCommand request, CancellationToken cancellationToken) 
        {
            var toDelete = _repository.GetPost(request.Id);
            
            if (toDelete.PostStatus != PostStatus.Open)

            {
                throw new InvalidOperationException();
            }

            _repository.DeletePost(toDelete.Id);
            return Unit.Value;
        }
    }
}
