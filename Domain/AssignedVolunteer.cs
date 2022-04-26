using FindPetOwner;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public class AssignedVolunteer : BaseEntity
    {
        public Guid Id { get; set; }

        public Guid AssignedToId { get; set; }
        public User AssignedTo { get; set; }

        public Guid PostId { get; set; }
        public FoundPetPost Post { get; set; }

        public DateTime ScheduledTime { get; set; }
        public AssignedStatus AssignedStatus { get; set; }
    }
}
