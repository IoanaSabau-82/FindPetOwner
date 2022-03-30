﻿using FindPetOwner;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class AssignedVolunteer
    {
        public Guid Id { get; set; }
        public User AssignedTo { get; set; }
        public FoundPetPost Post { get; set; }
        public DateTime ScheduledTime { get; set; }
        public AssignedStatus AssignedStatus { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}