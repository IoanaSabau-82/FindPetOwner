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
            return _context.FoundPetPosts.Include(x => x.CreatedBy)
                .FirstOrDefault(x => x.Id == id) ?? throw new EntityNotFoundException($"user with id {id} was not found");
        }

        public IEnumerable<FoundPetPost> GetPosts()
        {
            return _context.FoundPetPosts.Where(x => x.PostStatus != PostStatus.Closed).Include(x => x.CreatedBy);
        }

        public IEnumerable<FoundPetPost> GetPostsByUser(Guid createdById)
        {
            return _context.FoundPetPosts.Where(x => x.PostStatus != PostStatus.Closed && x.CreatedBy.Id == createdById)
                .Include(x => x.CreatedBy);
        }

        /*public void UpdatePicture(Picture postPicture)
        {
            _context.Pictures.Update(postPicture);
            _context.SaveChanges();
        }*/

        public void UpdatePost(FoundPetPost post)
        {
            var toUpdate = GetPost(post.Id);

            toUpdate.CreatedBy = post.CreatedBy;
            //toUpdate.Pictures = post.Pictures;
            toUpdate.Phone = post.Phone;
            toUpdate.Availability = post.Availability;
            toUpdate.Details = post.Details;
            toUpdate.Address = post.Address;
            toUpdate.Latitude = post.Latitude;
            toUpdate.Longitude = post.Longitude;
            toUpdate.PostStatus = post.PostStatus;
            toUpdate.CipId = post.CipId;

            _context.SaveChanges();
        }
    }
}
