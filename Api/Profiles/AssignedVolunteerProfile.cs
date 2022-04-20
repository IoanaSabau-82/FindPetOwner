using AutoMapper;
using Api.Dtos;
using Domain;
using Application.AssignedVolunteers.Commands.CreateAssignedVolunteers;
using Application.AssignedVolunteers.Commands.UpdateAssignedVolunteers;

namespace Api.Profiles
{
    public class AssignedVolunteerProfile : Profile
    {
        public AssignedVolunteerProfile()
        {
            CreateMap<AssignedVolunteerPutPostDto, CreateAssignedVolunteerCommand>();
            CreateMap<AssignedVolunteer, AssignedVolunteerGetDto>()
                .ReverseMap();
            CreateMap<AssignedVolunteerPutPostDto, UpdateAssignedVolunteerCommand>();

        }
    }
     
}
