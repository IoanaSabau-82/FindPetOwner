using Domain;
using FindPetOwner;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.FoundPetPosts.Commands.CreateFoundPetPost
{
    public class CreateFoundPetPostCommand: IRequest<FoundPetPost>
    {
        public Guid CreatedById { get; set; }
        public ICollection<Picture> Pictures{ get; set; }
        public string Phone { get; set; }
        public string Availability { get; set; }
        public string Details { get; set; }
        public string Address { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public PostStatus PostStatus { get; set; } = PostStatus.Open;
    }
}
