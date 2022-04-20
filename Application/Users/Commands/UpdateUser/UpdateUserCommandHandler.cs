using MediatR;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FindPetOwner;

namespace Application.Users.Commands.CreateUser
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, User>
    {
        private readonly IUserRepository _repository;

        public UpdateUserCommandHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public Task<User> Handle(UpdateUserCommand command, CancellationToken cancellationToken)
        {
            var user = new User
            {
                Id = command.Id,
                FirstName = command.FirstName,
                LastName = command.LastName,
                Email = command.Email,
                Phone = command.Phone,
                Address = command.Address,

            };

            _repository.UpdateUser(user);

            return Task.FromResult(user);
        }
    }
}
