using FindPetOwner;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public interface IUserRepository
    {
        User GetUser(Guid id);
        void CreateUser(User user);
        void UpdateUser(User user);
    }
}
