using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using MediatR;
using Api.Dtos;
using Application.Users.Commands;
using FindPetOwner;
using Application.Users.Commands.CreateUser;
using Application.Users.Queries;
using Domain.Exceptions;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public UsersController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(UserPutPostDto newUser)
        {
            
            var command = _mapper.Map<CreateUserCommand>(newUser);
            var created = await _mediator.Send(command);
            var dto = _mapper.Map<UserGetDto>(created);

            return CreatedAtAction(nameof(GetById), new { id = created.Id }, dto);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var query = new GetUserQuery { Id = id };
            var result = await _mediator.Send(query);

            if (result == null)
                return NotFound();

            var mappedResult = _mapper.Map<UserGetDto>(result);
            return Ok(mappedResult);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateUser(Guid id, [FromBody] UserPutPostDto updated)
        {
            var command = _mapper.Map<UpdateUserCommand>(updated);
            command.Id = id;

            var result = await _mediator.Send(command);

            if (result == null)
                return NotFound();

            return NoContent();
        }
    }
}
