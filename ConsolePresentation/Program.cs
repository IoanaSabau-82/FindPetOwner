using Application;
using Application.FoundPetPosts.Queries;
using Application.Users.Queries;
using Domain;
using FindPetOwner;
using Infrastructure;
using MediatR;
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
                .BuildServiceProvider();

            var mediator = diContainer.GetRequiredService<IMediator>();


            var users = await mediator.Send(new GetUserQuery(InMemory.User[0].Id));
            Console.WriteLine(users);

        }
    }
}