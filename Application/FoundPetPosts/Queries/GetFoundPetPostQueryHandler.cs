using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FindPetOwner;
using MediatR;
using Domain;

namespace Application.FoundPetPosts.Queries
{
    public class GetFoundPetPostQueryHandler: IRequestHandler<GetFoundPetPostQuery,FoundPetPost>
    {
        private readonly IFoundPetPostRepository _repository;

        public GetFoundPetPostQueryHandler(IFoundPetPostRepository repository)
        {
            _repository = repository;
        }

        public Task<FoundPetPost> Handle(GetFoundPetPostQuery query, CancellationToken cancellationToken)
        {
            var result = _repository.GetPost(query.Id);
            return Task.FromResult(result);
        }
    }
}
