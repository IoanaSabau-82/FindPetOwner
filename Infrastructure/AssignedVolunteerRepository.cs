using Application;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class AssignedVolunteerRepository : IAssignedVolunteerRepository
    {
        public void CreateAssigned(AssignedVolunteer assignedVolunteer)
        {
            assignedVolunteer.Id = Guid.NewGuid();
            InMemory.AssignedToPost.Add(assignedVolunteer);
        }

        public void DeleteAssignment(Guid id)//see note in the IRepository
        {
            var toDelete = InMemory.AssignedToPost.FirstOrDefault(x => x.Id == id) ?? throw new InvalidOperationException($"Assignment with id {id} not found");
        }

        public AssignedVolunteer GetAssignment(Guid id)
        {
            //si aici va trbui selectata si postarea aferenta
            return InMemory.AssignedToPost.FirstOrDefault(x => x.Id == id) ?? throw new InvalidOperationException($"Assignment with id {id} not found");
        }

        public IEnumerable<AssignedVolunteer> GetAssignmentsToPosts(Guid id)
        {
            /* ce anume returnez aici? ca nu mai e de assignedvolunteer dupa join
            var result = InMemory.AssignedToPost.Join(InMemory.Post, 
                assignment => assignment.Post.Id, post => post.Id, (assignment, post) => (assignment, post)).Where(x => x.assignment.AssignedTo.Id == id); //de vazut de care campuri este nevoie*/
            return InMemory.AssignedToPost.Where(x => x.AssignedTo.Id == id);
        }

        public void UpdateAssigned(AssignedVolunteer assignedVolunteer)
        {
            var toUpdate = InMemory.AssignedToPost.FirstOrDefault(x => x.Id == assignedVolunteer.Id) ?? throw new InvalidOperationException($"Assignment with id {assignedVolunteer.Id} not found");
            toUpdate.AssignedTo = assignedVolunteer.AssignedTo;
            toUpdate.Post = assignedVolunteer.Post;
            toUpdate.ScheduledTime = assignedVolunteer.ScheduledTime;
            toUpdate.AssignedStatus = assignedVolunteer.AssignedStatus;
        }
    }
}
