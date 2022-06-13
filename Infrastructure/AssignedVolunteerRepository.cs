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
    public class AssignedVolunteerRepository : IAssignedVolunteerRepository
    {
        private readonly FindPetOwnerContext _context;

        public AssignedVolunteerRepository(FindPetOwnerContext context)
        {
            _context = context;
        }


        public void CreateAssigned(AssignedVolunteer assignedVolunteer)
        {
            assignedVolunteer.Id = Guid.NewGuid();
            _context.AssignedVolunteers.Add(assignedVolunteer);
            _context.SaveChanges();
        }

        public void DeleteAssignment(Guid id)//see note in the IRepository
        {
            var toDelete = GetAssignment(id);
            _context.AssignedVolunteers.Remove(toDelete);
            _context.SaveChanges();
        }

        public AssignedVolunteer GetAssignment(Guid id)
        {
            return _context.AssignedVolunteers.Include(x => x.AssignedTo).
                Include(y => y.Post).ThenInclude(z=>z.CreatedBy).
                FirstOrDefault(x => x.Id == id) ?? throw new EntityNotFoundException($"user with id {id} was not found");
        }


        public IEnumerable<AssignedVolunteer> GetAssignmentsToPosts(Guid assignedToId)
        {
            return _context.AssignedVolunteers
                .Include(y => y.Post).ThenInclude(x=>x.CreatedBy)
                .Include(y => y.Post).ThenInclude(x=>x.Pictures)
                .Where(x => x.AssignedToId == assignedToId);
        }


        public void UpdateAssigned(AssignedVolunteer assignedVolunteer)
        {
            var toUpdate = GetAssignment(assignedVolunteer.Id);
            toUpdate.AssignedToId = assignedVolunteer.AssignedToId;
            toUpdate.PostId = assignedVolunteer.PostId;
            toUpdate.ScheduledTime = assignedVolunteer.ScheduledTime;
            toUpdate.AssignedStatus = assignedVolunteer.AssignedStatus;
            _context.SaveChanges();
        }
    }
}
