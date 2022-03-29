using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public interface IFoundPetPostRepository
    {
        IEnumerable<FoundPetPost> GetPosts();
        FoundPetPost GetPost(int id);
        void CreatePost(FoundPetPost post);
        void UpdatePost(FoundPetPost post);
        void DeletePost(FoundPetPost post);
    }
}
