using FindPetOwner;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace Application.FoundPetPosts.Queries
{
    public class GetOpenPostsQuery:IRequest<IEnumerable<FoundPetPost>>
    {
    }
}
