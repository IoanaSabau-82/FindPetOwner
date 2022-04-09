using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public interface IAssignedVolunteerRepository
    {
        IEnumerable<AssignedVolunteer> GetAssignmentsToPosts(Guid id);
        AssignedVolunteer GetAssignment(Guid id);
        void CreateAssigned(AssignedVolunteer assignedVolunteer);
        void UpdateAssigned(AssignedVolunteer assignedVolunteer);
        void DeleteAssignment(Guid id);// TODO: daca am zis ca nu se sterge de fapt, mai lasam delete? de fapt va fi doar un update de status
    }
}
