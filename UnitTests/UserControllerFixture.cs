using Api.Controllers;
using Application.Users.Queries;
using AutoMapper;
using FindPetOwner;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace UnitTests
{
	[TestClass]
	public class UserControllerFixture
	{
		private Mock<IMediator> _mockMediator;
		private Mock<IMapper> _mockMapper;
		private UsersController _target;

		[TestInitialize]
		public void InitialTestSetup()
		{
			_mockMediator = new Mock<IMediator>();
			_mockMapper = new Mock<IMapper>();
			_target = new UsersController(_mockMediator.Object, _mockMapper.Object);
		}


		[TestMethod]
		public async Task Should_Call_GetUserQuery_Once()
		{
			_mockMediator
				.Setup(m => m.Send(It.IsAny<GetUserQuery>(), It.IsAny<CancellationToken>()))
				.Verifiable();
			Guid userId = new("D2743AC3-83A5-40A9-324D-08DA236C3BCC");

			await _target.GetById(userId);

			_mockMediator.Verify(x => x.Send(It.IsAny<GetUserQuery>(), It.IsAny<CancellationToken>()), Times.Once());
		}



		[TestMethod]
		public async Task Given_IAmCalling_GetUserQuery_Then_UserWithCorrectIdIsCalled()
		{
			Guid Id = Guid.Empty;

			_mockMediator
				.Setup(m => m.Send(It.IsAny<GetUserQuery>(), It.IsAny<CancellationToken>()))
				.Returns<GetUserQuery, CancellationToken>(async (q, c) =>
				{
					Id = q.Id;
					return await Task.FromResult(
						new User
						{
							Id = q.Id,
							FirstName = "Jada",
							LastName = "Picket,",
							Email = "mail@example.com",
							Phone = "0750000000",
							Address = "Oradea"

						});
				});
			Guid userId = new("D2743AC3-83A5-40A9-324D-08DA236C3BCC");
			await _target.GetById(userId);

			Assert.AreEqual(Id, userId);
		}


		[TestMethod]
		public async Task Given_IAmCalling_GetUserQuery_Then_ReturnOkStatusCode()
		{
			_mockMediator
				.Setup(m => m.Send(It.IsAny<GetUserQuery>(), It.IsAny<CancellationToken>()))
				.ReturnsAsync(
						new User
						{
							Id = new("D2743AC3-83A5-40A9-324D-08DA236C3BCC"),
							/*FirstName = "Jada",
							LastName = "Picket,",
							Email = "mail@example.com",
							Phone = "0750000000",
							Address = "Oradea"*/

						});

			Guid userId = new("D2743AC3-83A5-40A9-324D-08DA236C3BCC");

			var result = await _target.GetById(userId);
			//creates a task with a completed result (although await should have done the trick? but there was no result on var result)
			var completedResult = Task.FromResult(result);
			var okResult = completedResult.Result as OkObjectResult;

			Assert.AreEqual((int)HttpStatusCode.OK, okResult.StatusCode);
		}



		/*[TestMethod]
		public async Task Given_IAmCalling_GetUserQuery_Then_ReturnTheUser()
		{
			var user = new User
			{
				Id = new("D2743AC3-83A5-40A9-324D-08DA236C3BCC"),
				FirstName = "Ioana",
				LastName = "Sabau",
				Email = "example@mail.com",
				Phone = "0750400400",
				Address = "Oradea"

			};
			_mockMediator
				.Setup(m => m.Send(It.IsAny<GetUserQuery>(), It.IsAny<CancellationToken>()))
				.ReturnsAsync(user);
			Guid userId = new("D2743AC3-83A5-40A9-324D-08DA236C3BCC");

			var result = await _target.GetById(userId);

			var completedResult = Task.FromResult(result);

			var okResult = completedResult.Result as OkObjectResult;


			Assert.AreEqual(user, actual: okResult.Value);

		}*/

	}
}