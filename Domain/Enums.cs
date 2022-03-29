using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Enums
    {
        public enum PostStatus { Open = 0, Pending = 1, CipFound = 2, Closed = 3 };
        public enum AssignedStatus { Scheduled = 0, Cancelled = 1, Completed=2 };

    }   
}
