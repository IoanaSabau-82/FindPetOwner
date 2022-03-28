using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public interface IUser:IMemoryItem
    {

        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; } // optional, must be filled in by the volunteers to be able to receive calendar events

        public string Phone { get; set; } //optional

        public string Address { get; set; } //optional

        public virtual string ToString()
        {
            return $"{FirstName} {LastName }";
        }
        public IEnumerable<IPost> GetAll();

        public IEnumerable<IPost> GetById();

        public void CreatePost();

        public void UpdatePost();
       
        public void DeletePost();

    }
}
