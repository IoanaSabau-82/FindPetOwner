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
    public class GetFoundPetPostsByUserQueryHandler: IRequestHandler<GetFoundPetPostsByUserQuery,IEnumerable<FoundPetPost>>
    {
        private readonly IFoundPetPostRepository _repository;

        public GetFoundPetPostsByUserQueryHandler(IFoundPetPostRepository repository)
        {
            _repository = repository;
        }

        public Task<IEnumerable<FoundPetPost>> Handle(GetFoundPetPostsByUserQuery query, CancellationToken cancellationToken)
        {
            var result = _repository.GetPostsByUser(query.CreatedById);
            return Task.FromResult(result);
        }
    }
}
