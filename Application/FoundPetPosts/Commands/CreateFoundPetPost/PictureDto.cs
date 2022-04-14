using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.FoundPetPosts.Commands.CreateFoundPetPost
{
    public class PictureDto
    {
        public string Name { get; set; }
        public string FilePath { get; set; }

        public FoundPetPost Post { get; set; }
    }
}
