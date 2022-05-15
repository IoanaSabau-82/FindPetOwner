using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Picture
    {
        public Guid Id { get; set; }
        public string Url { get; set; }

        public Guid FoundPetPostId { get; set; }
        public FoundPetPost Post { get; set; }

    }
}
