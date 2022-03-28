// See https://aka.ms/new-console-template for more information
using FindPetOwner;
using Domain;


RegularUser user = new(1,"john", "doe","");
Console.WriteLine(user.FirstName);
FoundPetPost post = new(user);
Console.WriteLine(post.user.FirstName);
Console.WriteLine(post.Status);

