using Domain;
using FindPetOwner;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.FoundPetPosts.Commands.DeleteFoundPetPost
{
    public class DeleteFoundPetPostCommand: IRequest
    {
        public FoundPetPost post;
    }
}
