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
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Guid>
    {
        private readonly IUserRepository _repository; //de ce declaram asta aici?

        public CreateUserCommandHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public Task<Guid> Handle(CreateUserCommand command, CancellationToken cancellationToken)
        {
            var user = new User
            {
                FirstName = command.FirstName,
                LastName = command.LastName,
                Email = command.Email,
                Phone = command.Phone,
                Address = command.Address,
                //? needed?
                CreatedAt = command.CreatedAt
            };

            _repository.CreateUser(user);

            return Task.FromResult(user.Id);
        }
    }
}
