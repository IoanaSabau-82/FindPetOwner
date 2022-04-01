using Application;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class FoundPetPostRepository : IFoundPetPostRepository
    {
        public void CreatePost(FoundPetPost post)
        {
            post.Id = Guid.NewGuid();
            InMemory.Post.Add(post);
        }

        public void DeletePost(Guid id)
        {
            var toDelete = InMemory.Post.FirstOrDefault(x => x.Id == id);
            if (toDelete == null) 
            {
                throw new InvalidOperationException($"Post with id {id} not found");
            }
            else if (toDelete.PostStatus == 0)
            {
                InMemory.Post.Remove(toDelete);
            }
            else
            {
                //TODO: throw the proper exception or create custom one
                throw new Exception();
            }
        }

        public FoundPetPost GetPost(Guid id)
        {
            return InMemory.Post.FirstOrDefault(x => x.Id == id) ?? throw new InvalidOperationException($"Post with id {id} not found");
        }

        public IEnumerable<FoundPetPost> GetPosts()
        {
            return InMemory.Post;
        }

        public void UpdatePost(Guid id)
        {
            var toUpdate = InMemory.Post.FirstOrDefault(x => x.Id == id) ?? throw new InvalidOperationException($"User with id {id} not found");
            //TODO: implement update mechanism
        }
    }
}
