using AutoMapper;
using Api.Dtos;
using Domain;
using Application.AssignedVolunteers.Commands.CreateAssignedVolunteers;
using Application.AssignedVolunteers.Commands.UpdateAssignedVolunteers;
using FindPetOwner;

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
            CreateMap<UserIdDto, User>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ReverseMap();
            CreateMap<PostIdDto, FoundPetPost>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ReverseMap();
        }
    }

}
