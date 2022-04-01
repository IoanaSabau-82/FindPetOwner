using FindPetOwner;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class FoundPetPost
    {
        public Guid Id { get; set; }
        public User CreatedBy { get; set; }
        public Dictionary<int, object> Pictures { get; set; }
        public string Phone { get; set; }
        public List<DateTime> Availability { get; set; }
        public string Comment { get; set; }
        public string Address { get; set; }
        public List<double> GPScoordinates { get; set; }
        public PostStatus PostStatus { get; set; }
        public ulong? CipId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }

    
}


