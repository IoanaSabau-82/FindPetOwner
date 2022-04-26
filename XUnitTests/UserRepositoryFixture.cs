using FindPetOwner;
using Infrastructure;
using Infrastructure.Data;
using Moq;
using Xunit;

namespace XUnitTests
{
    public class UserRepositoryFixture
    {
        private Mock<FindPetOwnerContext> _mockContext;
        private UserRepository _target;

        public UserRepositoryFixture()
        {
            //se poate face mock direct pe baza de date? no interface?
            _mockContext = new Mock<FindPetOwnerContext>(null);
            _target = new UserRepository(_mockContext.Object);
        }
        
        [Fact]
        public void ShouldCreateUser()
        {
            //arrange
            var user = new User
            {
               FirstName = "Johny",
               LastName = "Deep",
               Address = "Oradea",
               Phone = "0755400400",
               Email = "example@mail.com"
            };

            _mockContext.Setup(x => x.Add(user)).Verifiable();

            //act
            _target.CreateUser(user);

            //assert
            _mockContext.Verify(x => x.Add(user),Times.Once());


        }
    }
}