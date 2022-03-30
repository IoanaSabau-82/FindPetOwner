using Domain;
using FindPetOwner;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public interface IAssignVolunteerRepository
    {
        IEnumerable<AssignedVolunteer> GetAssignmentsToPosts(User AssignedTo);
        AssignedVolunteer GetAssignment(Guid id);
        void CreateAssigned(AssignedVolunteer assignVolunteer);
        void UpdateAssigned(AssignedVolunteer assignVolunteer);
        void DeleteAssignment(AssignedVolunteer assignVolunteer);//daca am zis ca nu se sterge de fapt, mai lasam delete? de fapt va fi doar un update de status
    }
}
