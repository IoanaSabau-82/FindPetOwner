using Application.FoundPetPosts.Commands.CreateFoundPetPost;
using AutoMapper;
using Api.Dtos;
using Domain;
using Application.FoundPetPosts.Commands.UpdateFoundPetPost;
using FindPetOwner;
using Api.Dtos.FoundPetPosts;

namespace Api.Profiles
{
    public class FoundPetPostProfile : Profile
    {
        public FoundPetPostProfile()
        {
            CreateMap<FoundPetPostPutPostDto, CreateFoundPetPostCommand>();
            CreateMap<FoundPetPost, FoundPetPostGetDto>()
                .ReverseMap();
            CreateMap<User, PostCreatedByGetDto>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.FirstName + " " + src.LastName))
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));
            CreateMap<UserIdDto,User>()
                 .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ReverseMap();
            CreateMap<Picture,PictureDto>().ReverseMap();
            CreateMap<FoundPetPostPutPostDto, UpdateFoundPetPostCommand>();

        }
    }
     
}
