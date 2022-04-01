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
            return InMemory.AssignedToPost.FirstOrDefault(x => x.Id == id) ?? throw new InvalidOperationException($"Assignment with id {id} not found");
        }

        public IEnumerable<AssignedVolunteer> GetAssignmentsToPosts(Guid id)
        {
            return InMemory.AssignedToPost.Where(x => x.AssignedTo.Id == id);
        }

        public void UpdateAssigned(Guid id)
        {
            var toUpdate = InMemory.AssignedToPost.FirstOrDefault(x => x.Id == id) ?? throw new InvalidOperationException($"Assignment with id {id} not found");
            //TODO: implement update mechanism
        }
    }
}
