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
    public class GetOpenPostsQueryHandler: IRequestHandler<GetOpenPostsQuery,IEnumerable<FoundPetPost>>
    {
        private readonly IFoundPetPostRepository _repository;

        public GetOpenPostsQueryHandler(IFoundPetPostRepository repository)
        {
            _repository = repository;
        }

        public Task<IEnumerable<FoundPetPost>> Handle(GetOpenPostsQuery query, CancellationToken cancellationToken)
        {
            var result = _repository.GetPostsForAssignments();
            return Task.FromResult(result);
        }
    }
}
