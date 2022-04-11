using Application;
using Domain;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class FoundPetPostRepository : IFoundPetPostRepository
    {

        private readonly FindPetOwnerContext _context;

        public FoundPetPostRepository(FindPetOwnerContext context)
        {
            _context = context;
        }

        public void CreatePost(FoundPetPost post)
        {
            post.Id = Guid.NewGuid();
            _context.FoundPetPosts.Add(post);
            _context.SaveChanges();
        }

        public void DeletePost(Guid id)
        {
            var toDelete = _context.FoundPetPosts.FirstOrDefault(x => x.Id == id);

            if (toDelete == null) 
            {
                throw new InvalidOperationException($"Post with id {id} not found");
            }

            _context.FoundPetPosts.Remove(toDelete);
            _context.SaveChanges();

        }

        public FoundPetPost GetPost(Guid id)
        {
            return _context.FoundPetPosts.FirstOrDefault(x => x.Id == id) ?? throw new InvalidOperationException($"Post with id {id} not found");
        }

        public IEnumerable<FoundPetPost> GetPosts()
        {
            return _context.FoundPetPosts;
        }

        public void UpdatePost(FoundPetPost post)
        {
            var toUpdate = _context.FoundPetPosts.FirstOrDefault(x => x.Id == post.Id) ?? throw new InvalidOperationException($"User with id {post.Id} not found");
            toUpdate.CreatedBy = post.CreatedBy;
            toUpdate.Pictures = post.Pictures;
            toUpdate.Phone = post.Phone;
            toUpdate.AvailabilityStart = post.AvailabilityStart;
            toUpdate.AvailabilityEnd = post.AvailabilityEnd;
            toUpdate.Comment = post.Comment;
            toUpdate.Address = post.Address;
            toUpdate.Latitude = post.Latitude;
            toUpdate.Longitude = post.Longitude;
            toUpdate.PostStatus = post.PostStatus;
            toUpdate.CipId = post.CipId;
            _context.SaveChanges();
        }
    }
}
