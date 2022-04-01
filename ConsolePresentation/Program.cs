// See https://aka.ms/new-console-template for more information
using FindPetOwner;
using Domain;

{
    var user = new User();
    var user1 = new User();
    user.Id = Guid.NewGuid();

    user.FirstName = "John";
    Console.WriteLine(user.FirstName);
    Console.WriteLine(user.Id);
    FoundPetPost foundPost = new();
    //foundPost.Status = Status.open;
    foundPost.CreatedBy = user;
    Console.WriteLine(foundPost.CreatedBy);
    Console.WriteLine(foundPost.PostStatus);


}

