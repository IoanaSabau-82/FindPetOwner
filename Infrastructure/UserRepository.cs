using Application;
using FindPetOwner;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class UserRepository : IUserRepository
    {
        public void CreateUser(User user)
        {
            user.Id = Guid.NewGuid();
            InMemory.User.Add(user);
        }

        public User GetUser(Guid id)
        {
            return InMemory.User.FirstOrDefault(x => x.Id == id) ?? throw new InvalidOperationException($"User with id {id} not found");
        }

        public void UpdateUser(User user)
        {
            var toUpdate = InMemory.User.FirstOrDefault(x => x.Id == user.Id) ?? throw new InvalidOperationException($"User with id {user.Id} not found");
            toUpdate.FirstName = user.FirstName;
            toUpdate.LastName = user.LastName;
            toUpdate.Email = user.Email;
            toUpdate.Phone = user.Phone;
            toUpdate.Address = user.Address;
        }
    }
}
