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
            var toDelete = _context.AssignedVolunteers.FirstOrDefault(x => x.Id == id) ?? throw new EntityNotFoundException($"user with id {id} was not found");
            _context.SaveChanges();
        }

        public AssignedVolunteer GetAssignment(Guid id)
        {
            //si aici va trbui selectata si postarea aferenta
            return _context.AssignedVolunteers.FirstOrDefault(x => x.Id == id) ?? throw new EntityNotFoundException($"user with id {id} was not found");
        }

        public IEnumerable<AssignedVolunteer> GetAssignmentsToPosts(Guid id)
        {
            return _context.AssignedVolunteers.Where(x => x.AssignedTo.Id == id);
                //.Include(a => a.Post);
        }

        public void UpdateAssigned(AssignedVolunteer assignedVolunteer)
        {
            var toUpdate = _context.AssignedVolunteers.FirstOrDefault(x => x.Id == assignedVolunteer.Id) ?? throw new InvalidOperationException($"Assignment with id {assignedVolunteer.Id} not found");
            toUpdate.AssignedTo = assignedVolunteer.AssignedTo;
            toUpdate.Post = assignedVolunteer.Post;
            toUpdate.ScheduledTime = assignedVolunteer.ScheduledTime;
            toUpdate.AssignedStatus = assignedVolunteer.AssignedStatus;
            _context.SaveChanges();
        }
    }
}
