using Api.Dtos;
using Application.AssignedVolunteers.Commands.CreateAssignedVolunteers;
using Application.AssignedVolunteers.Queries;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssignedVolunteersController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public AssignedVolunteersController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreatePost(AssignedVolunteerPutPostDto newPost)
        {

            var command = _mapper.Map<CreateAssignedVolunteerCommand>(newPost);
            var created = await _mediator.Send(command);
            var dto = _mapper.Map<AssignedVolunteerGetDto>(created);

            return CreatedAtAction(nameof(GetById), new { id = created.Id }, dto);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var query = new GetAssignedVolunteerPostQuery { Id = id };
            var result = await _mediator.Send(query);

            if (result == null)
                return NotFound();

            var mappedResult = _mapper.Map<AssignedVolunteerGetDto>(result);
            return Ok(mappedResult);
        }

        [HttpGet]
        [Route("posts/{AssignedToid}")]
        public async Task<IActionResult> Getall(Guid AssignedToid)
        {
            var query = new GetAssignedVolunteerPostsQuery { Id = AssignedToid };
            var result = await _mediator.Send(query);
            var mappedResult = _mapper.Map<List<AssignedVolunteerByUserGetDto>>(result);
            return Ok(mappedResult);


        }
    }
}
