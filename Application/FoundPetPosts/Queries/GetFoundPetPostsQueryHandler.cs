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
    public class GetFoundPetPostsQueryHandler: IRequestHandler<GetFoundPetPostsQuery,IEnumerable<FoundPetPost>>
    {
        private readonly IFoundPetPostRepository _repository;

        public GetFoundPetPostsQueryHandler(IFoundPetPostRepository repository)
        {
            _repository = repository;
        }

        public Task<IEnumerable<FoundPetPost>> Handle(GetFoundPetPostsQuery query, CancellationToken cancellationToken)
        {
            var result = _repository.GetPosts();
            return Task.FromResult(result);
        }
    }
}
