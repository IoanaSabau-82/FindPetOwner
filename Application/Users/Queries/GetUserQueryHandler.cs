using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FindPetOwner;
using MediatR;

namespace Application.Users.Queries
{
    public class GetUserQueryHandler: IRequestHandler<GetUserQuery,User>
    {
        private readonly IUserRepository _repository;

        public GetUserQueryHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public Task<User> Handle(GetUserQuery query, CancellationToken cancellationToken)
        {
            var result = _repository.GetUser(query.Id);
            return Task.FromResult(result);
        }
    }
}
