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
        User GetUser(int id);//ar fi nevoie pentru adaugarea userului la post sau la assignvolunteer?
        void CreateUser(User user);//aici nu inteleg de ce la create este ca parametru user, nu ar trebui sa fie nimic, nu?
        void UpdateUser(User user);//sa fie dupa id?
    }
}
