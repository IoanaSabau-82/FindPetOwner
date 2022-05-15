using FindPetOwner;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class FoundPetPost :BaseEntity
    {
        public Guid Id { get; set; }

        public Guid CreatedById { get; set; }
        public User CreatedBy { get; set; }
        public string Phone { get; set; }
        public string Availability { get; set; }
        public string Details { get; set; }
        public string Address { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public PostStatus PostStatus { get; set; }
        public long CipId { get; set; }

        public ICollection<AssignedVolunteer> AssignedVolunteers { get; set; }
        public ICollection<Picture> Pictures { get; set; }
    }

    
}


