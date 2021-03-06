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
        IEnumerable<FoundPetPost> GetPostsByUser(Guid createdById);
        FoundPetPost GetPost(Guid id);
        IEnumerable<FoundPetPost> GetPostsForAssignments();
        void CreatePost(FoundPetPost post);
        void UpdatePost(FoundPetPost post);
        void UpdatePostStatus(Guid id, int status);
        void DeletePost(Guid id);
    }
}
