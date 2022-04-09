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

            InMemory.Post.Remove(toDelete);

        }

        public FoundPetPost GetPost(Guid id)
        {
            return InMemory.Post.FirstOrDefault(x => x.Id == id) ?? throw new InvalidOperationException($"Post with id {id} not found");
        }

        public IEnumerable<FoundPetPost> GetPosts()
        {
            return InMemory.Post;
        }

        public void UpdatePost(FoundPetPost post)
        {
            var toUpdate = InMemory.Post.FirstOrDefault(x => x.Id == post.Id) ?? throw new InvalidOperationException($"User with id {post.Id} not found");
            toUpdate.CreatedBy = post.CreatedBy;
            toUpdate.Pictures = post.Pictures;
            toUpdate.Phone = post.Phone;
            toUpdate.Availability = post.Availability;
            toUpdate.Comment = post.Comment;
            toUpdate.Address = post.Address;
            toUpdate.GPScoordinates = post.GPScoordinates;
            toUpdate.PostStatus = post.PostStatus;
            toUpdate.CipId = post.CipId;
        }
    }
}
