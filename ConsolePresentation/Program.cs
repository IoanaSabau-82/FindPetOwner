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


            await using var context = new FindPetOwnerContext();
            var user1 = await mediator.Send(new GetUserQuery(Guid.Parse("6DAE81AF-09B1-46E3-AF1F-8C86D39C7641")));

            var post = await mediator.Send(new CreateFoundPetPostCommand
            {
                CreatedBy = user1,

            }
            );

            /*var user = await mediator.Send(new CreateUserCommand 
            {
                FirstName = "Alan",
                LastName = "Derby",
                Address = "Manchester",
                Email = "alan@mail.com",
                Phone = "0700456456"
            });


            Console.WriteLine(user1.FirstName);*/



            /*var findPetContext = new FindPetOwnerContext();
            var user1 = findPetContext.Users.Where(x => x.FirstName == "Alan").First();

            /*findPetContext.Add(new Picture
            {
                Name = "pic6",
                Post = null
            }) ;
            findPetContext.SaveChanges();

            findPetContext.Add(new FoundPetPost
            {
                CreatedBy = user1,

                Pictures = new() { new Picture
                {
                    Name = "pic7"
                }
                },
            }
            ) ;
           findPetContext.SaveChanges();

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

            /*var folderName = @"C:\Assignments\FindPetOwner\Pictures";
            var post = new FoundPetPost();
            var fileName = @"picture2";
            var postDirPath = Path.Combine(folderName,post.Id.ToString());
            Directory.CreateDirectory(postDirPath);
            var filePath = Path.Combine(postDirPath, fileName + ".txt");
            var fileStream = File.Create(filePath);
            using (var sw = new StreamWriter(fileStream))
                await sw.WriteLineAsync($"this is {fileName}");*/

        }
    }
}