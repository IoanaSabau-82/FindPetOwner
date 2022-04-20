using Application;
using Domain;
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
            var toDelete = _context.AssignedVolunteers.FirstOrDefault(x => x.Id == id) ?? throw new InvalidOperationException($"Assignment with id {id} not found");
            _context.SaveChanges();
        }

        public AssignedVolunteer GetAssignment(Guid id)
        {
            //si aici va trbui selectata si postarea aferenta
            return _context.AssignedVolunteers.FirstOrDefault(x => x.Id == id) ?? throw new InvalidOperationException($"Assignment with id {id} not found");
        }

        public IEnumerable<AssignedVolunteer> GetAssignmentsToPosts(Guid id)
        {
            /* ce anume returnez aici? ca nu mai e de assignedvolunteer dupa join
            var result = InMemory.AssignedToPost.Join(InMemory.Post, 
                assignment => assignment.Post.Id, post => post.Id, (assignment, post) => (assignment, post)).Where(x => x.assignment.AssignedTo.Id == id); //de vazut de care campuri este nevoie*/
            return _context.AssignedVolunteers.Where(x => x.AssignedTo.Id == id).Include(a => a.AssignedTo);
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
