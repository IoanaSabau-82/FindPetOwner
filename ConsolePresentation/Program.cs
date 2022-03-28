// See https://aka.ms/new-console-template for more information
using FindPetOwner;
using Domain;

{
    User user = new();
    user.FirstName = "John";
    Console.WriteLine(user.FirstName);
    Console.WriteLine(user.Id);
    FoundPetPost foundPost = new();
    //foundPost.Status = Status.open;
    foundPost.User = user;
    Console.WriteLine(foundPost.User);
    Console.WriteLine(foundPost.Status);
    SignUpPost signUpPost = new();


}

