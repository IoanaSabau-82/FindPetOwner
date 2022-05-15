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
        public string Pictures { get; set; }
        public string Phone { get; set; }
        public string Availability { get; set; }
        public string Details { get; set; }
        public string Address { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public PostStatus PostStatus { get; set; }
    }
}
