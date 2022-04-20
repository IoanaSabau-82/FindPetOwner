using Application.FoundPetPosts.Commands.CreateFoundPetPost;
using AutoMapper;
using Api.Dtos;
using Domain;
using Application.FoundPetPosts.Commands.UpdateFoundPetPost;

namespace Api.Profiles
{
    public class FoundPetPostProfile : Profile
    {
        public FoundPetPostProfile()
        {
            CreateMap<FoundPetPostPutPostDto, CreateFoundPetPostCommand>();
            CreateMap<FoundPetPost, FoundPetPostGetDto>()
                .ReverseMap();
            CreateMap<FoundPetPostPutPostDto, UpdateFoundPetPostCommand>();

        }
    }
     
}
