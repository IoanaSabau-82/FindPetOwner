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
            user.Id= Guid.NewGuid();
            InMemory.InMemoryUser.Add(user);
        }

        public User GetUser(Guid id)
        {
            return InMemory.InMemoryUser.FirstOrDefault(x => x.Id == id);//fac si aici doar cu first si try. catch?
        }

        public void UpdateUser(Guid id)
        {
            var toUpdate = InMemory.InMemoryUser.FirstOrDefault(x => x.Id == id);
            if (toUpdate == null) throw new InvalidOperationException($"User with id {id} not found");
            toUpdate.FirstName=Console.ReadLine();
        }
    }
}
