using Application;
using Domain.Exceptions;
using FindPetOwner;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class UserRepository : IUserRepository
    {

        private readonly FindPetOwnerContext _context;

        public UserRepository(FindPetOwnerContext context)
        {
            _context = context;
        }

        public void CreateUser(User user)
        {
            user.Id = Guid.NewGuid();
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public User GetUser(Guid id)
        {
            return _context.Users
                .FirstOrDefault(x => x.Id == id) ?? throw new EntityNotFoundException($"user with id {id} was not found");
        }

        public void UpdateUser(User user)
        {
            var toUpdate = GetUser(user.Id);

            toUpdate.FirstName = user.FirstName;
            toUpdate.LastName = user.LastName;
            toUpdate.Email = user.Email;
            toUpdate.Phone = user.Phone;
            toUpdate.Address = user.Address;
            _context.SaveChanges();
        }
    }
}
