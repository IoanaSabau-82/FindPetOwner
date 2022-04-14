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
        public Picture(string name, string filePath)
        {
            Name = name;
            FilePath = filePath;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string FilePath { get; set; }

        public FoundPetPost Post { get; set; }

        
    }
}
