using Api.Dtos;
using Application.Users.Commands.CreateUser;
using AutoMapper;
using FindPetOwner;

namespace Api.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserPutPostDto, CreateUserCommand>()
                .ReverseMap();

            CreateMap<UserPutPostDto, UpdateUserCommand>()
                .ReverseMap();

            CreateMap<User, UserGetDto>()
                .ReverseMap();
        }
    }
}
