using Api.Dtos;
using Application.AssignedVolunteers.Commands.CreateAssignedVolunteers;
using Application.AssignedVolunteers.Commands.UpdateAssignedVolunteers;
using Application.AssignedVolunteers.Queries;
using Application.FoundPetPosts.Queries;
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

            var mappedResult = _mapper.Map<AssignedVolunteerGetDto>(result);
            return Ok(mappedResult);
        }

        [HttpGet]
        [Route("posts/{assignedToId}")]
        public async Task<IActionResult> Getall(Guid assignedToId)
        {
            var query = new GetAssignedVolunteerPostsQuery {AssignedToId = assignedToId };
            var result = await _mediator.Send(query);
            var mappedResult = _mapper.Map<List<AssignedVolunteerGetDto>>(result);
           
            return Ok(mappedResult);
        }


        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateAssignment(Guid id, [FromBody] AssignedVolunteerPutPostDto updated)
        {
            var command = _mapper.Map<UpdateAssignedVolunteerCommand>(updated);
            command.Id = id;

            await _mediator.Send(command);

            return NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> PostsForAssignments()
        {
            var query = new GetOpenPostsQuery();
            var result = await _mediator.Send(query);
            var mappedResult = _mapper.Map<List<FoundPetPostGetDto>>(result);
            return Ok(mappedResult);

        }
    }
}
