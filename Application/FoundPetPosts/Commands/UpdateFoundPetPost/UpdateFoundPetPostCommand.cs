using Domain;
using FindPetOwner;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.FoundPetPosts.Commands.UpdateFoundPetPost
{
    public class UpdateFoundPetPostCommand: IRequest<FoundPetPost>
    {
        public Guid Id { get; set; }
        public Guid CreatedById { get; set; }
        public ICollection<Picture> Pictures { get; set; }
        public string Phone { get; set; }
        public string Availability { get; set; }
        public string Details { get; set; }
        public string Address { get; set; }
        public double Lat { get; set; }
        public double Lng { get; set; }
        public PostStatus PostStatus { get; set; }
        public long CipId { get; set; }
    }
}
