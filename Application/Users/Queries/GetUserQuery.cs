using FindPetOwner;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.Queries
{
    public class GetUserQuery:IRequest<User>
    {
        /*public GetUserQuery(Guid id)
        {
            Id = id;
        }*/

        public Guid Id { get; set; }
    }
}
