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

        //cum sa ii dau atunci idul??
        public Task<User> Handle(Guid id, GetUserQuery query, CancellationToken cancellationToken)
        {
            var result = _repository.GetUser(id);
            return Task.FromResult(result);
        }

        public Task<User> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
