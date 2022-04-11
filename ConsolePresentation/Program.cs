using Application;
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
                .BuildServiceProvider();

            var mediator = diContainer.GetRequiredService<IMediator>();


            await using var context = new FindPetOwnerContext();

            /*var user = await mediator.Send(new CreateUserCommand 
            {
                FirstName = "Alan",
                LastName = "Derby",
                Address = "Manchester",
                Email = "alan@mail.com",
                Phone = "0700456456"
            });*/

            var user = await mediator.Send(new GetUserQuery(Guid.Parse("23532F7B-152F-4F60-81BB-C706CD98B9FE")));
            Console.WriteLine(user);

            //var findPetContext = new FindPetOwnerContext();

            /*findPetContext.Add(new User
            {
                FirstName = "John",
                LastName = "Row",
                Email = "john@mail.com",
                Phone = "0744500501",
                Address = "this is my adress",
            });
            findPetContext.SaveChanges();

            var toupdate = findPetContext.Users.Where(u => u.FirstName == "John").First();
            toupdate.Email = "john's_email@mail.com";
            findPetContext.SaveChanges();*/
        }
    }
}