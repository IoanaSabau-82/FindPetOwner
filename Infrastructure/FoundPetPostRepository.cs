using Application;
using Domain;
using Domain.Exceptions;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
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
            var toDelete = GetPost(id);

            _context.FoundPetPosts.Remove(toDelete);
            _context.SaveChanges();
        }

        public FoundPetPost GetPost(Guid id)
        {
            return _context.FoundPetPosts.Include(x => x.CreatedBy).Include(x=>x.Pictures)
                .FirstOrDefault(x => x.Id == id) ?? throw new EntityNotFoundException($"post with id {id} was not found");
        }

        public IEnumerable<FoundPetPost> GetPosts()
        {
            return _context.FoundPetPosts.Where(x => x.PostStatus != PostStatus.Closed).Include(x => x.CreatedBy).Include(x => x.Pictures);
        }

        public IEnumerable<FoundPetPost> GetPostsForAssignments()
        {
            return _context.FoundPetPosts.Where(x => x.PostStatus == 0).Include(x => x.CreatedBy).Include(x => x.Pictures);
        }

        public IEnumerable<FoundPetPost> GetPostsByUser(Guid createdById)
        {
            return _context.FoundPetPosts.Where(x => x.PostStatus != PostStatus.Closed && x.CreatedBy.Id == createdById)
                .Include(x => x.CreatedBy).Include(x => x.Pictures);
        }

        public void UpdatePost(FoundPetPost post)
        {
            var toUpdate = GetPost(post.Id);

            if (toUpdate.Pictures != null)
            {
                foreach (var pic in toUpdate.Pictures)
                {
                    foreach (var pic1 in post.Pictures)
                    {
                        if (pic1.Url == pic.Url)
                        {
                            post.Pictures.Remove(pic);
                        }
                    }
                }
            }
            toUpdate.CreatedById = post.CreatedById;
            toUpdate.Pictures = post.Pictures;
            toUpdate.Phone = post.Phone;
            toUpdate.Availability = post.Availability;
            toUpdate.Details = post.Details;
            toUpdate.Address = post.Address;
            toUpdate.Lat = post.Lat;
            toUpdate.Lng = post.Lng;
            toUpdate.PostStatus = post.PostStatus;
            toUpdate.CipId = post.CipId;

            _context.SaveChanges();
        }

        public void UpdatePostStatus(Guid id, int status)
        {
            var toUpdate = GetPost(id);

            toUpdate.PostStatus = (PostStatus)status;

            _context.SaveChanges();
        }
    }
}
