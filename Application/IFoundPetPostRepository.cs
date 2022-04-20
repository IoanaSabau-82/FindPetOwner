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
        FoundPetPost GetPost(Guid id);
        void CreatePost(FoundPetPost post);
        //void UpdatePicture(Picture postPicture);
        void UpdatePost(FoundPetPost post);
        void DeletePost(Guid id);
    }
}
