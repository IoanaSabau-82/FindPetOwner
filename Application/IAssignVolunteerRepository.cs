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
        IEnumerable<AssignVolunteer> GetAssignmentsToPosts(User AssignedTo);
        void CreateAssigned(AssignVolunteer assignVolunteer);
        void UpdateAssigned(AssignVolunteer assignVolunteer);
        void DeleteAssignment(AssignVolunteer assignVolunteer);//daca am zis ca nu se sterge de fapt, mai lasam delete? de fapt va fi doar un update de status
    }
}
