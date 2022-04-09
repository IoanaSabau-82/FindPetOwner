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
        public User CreatedBy { get; set; }
        public Dictionary<int, byte> Pictures { get; set; }
        public string Phone { get; set; }
        public List<DateTime> Availability { get; set; }
        public string Comment { get; set; }
        public string Address { get; set; }
        public List<double> GPScoordinates { get; set; }
        public PostStatus PostStatus { get; set; } = PostStatus.Open;
    }
}
