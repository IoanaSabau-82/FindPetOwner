using Application;
using Application.FoundPetPosts.Commands.CreateFoundPetPost;
using Application.FoundPetPosts.Queries;
using Application.Users.Commands.CreateUser;
using Application.Users.Queries;
using Domain;
using FindPetOwner;
using Infrastructure;
using Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;



namespace ConsolePresentation
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {

            var diContainer = new ServiceCollection()
                .AddMediatR(typeof(IUserRepository).Assembly)
                .AddScoped<IUserRepository, UserRepository>()
                .AddScoped<IFoundPetPostRepository, FoundPetPostRepository>()
                .AddScoped<IAssignedVolunteerRepository, AssignedVolunteerRepository>()
                .AddDbContext<FindPetOwnerContext>()
                .BuildServiceProvider();

            var mediator = diContainer.GetRequiredService<IMediator>();


           /* var user = await mediator.Send(new CreateUserCommand 
            {
                FirstName = "John",
                LastName = "Doe",
                Address = "Manchester",
                Email = "alan@mail.com",
                Phone = "0700456456"
            });


            var post = await mediator.Send(new CreateFoundPetPostCommand
                { 
                    Comment = "comentARFIU",
                    CreatedBy = user,
                    Pictures = new()
                    { 
                        new Picture() {Name = "pic15" },
                        new Picture() { Name = "pic16" },
                    }
                }
            );*/




        }
    }
}