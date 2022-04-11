using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Picture :BaseEntity
    {
        public Guid Id { get; set; }
        [NotMapped]
        public string Name { get; set; }
        public string FilePath { get; private set; }

        public FoundPetPost Post { get; set; }
        
    }
}
