using Api.Dtos;
using Application.FoundPetPosts.Commands.CreateFoundPetPost;
using Application.FoundPetPosts.Commands.DeleteFoundPetPost;
using Application.FoundPetPosts.Commands.UpdateFoundPetPost;
using Application.FoundPetPosts.Queries;
using AutoMapper;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoundPetPostsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public FoundPetPostsController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreatePost(FoundPetPostPutPostDto newPost)
        {

            var command = _mapper.Map<CreateFoundPetPostCommand>(newPost);
            var created = await _mediator.Send(command);
            var dto = _mapper.Map<FoundPetPostGetDto>(created);

            return CreatedAtAction(nameof(GetById), new { id = created.Id }, dto);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var query = new GetFoundPetPostQuery { Id = id };
            var result = await _mediator.Send(query);

            if (result == null)
                return NotFound();

            var mappedResult = _mapper.Map<FoundPetPostGetDto>(result);
            return Ok(mappedResult);
        }


        [HttpGet]
        [Route("posts/{createdById}")]
        public async Task<IActionResult> GetAllByUser(Guid createdById)
        {
            var query = new GetFoundPetPostsByUserQuery { CreatedById = createdById };
            var result = await _mediator.Send(query);

            var mappedResult = _mapper.Map<List<FoundPetPostGetDto>>(result);
            return Ok(mappedResult);
        }


        [Route("{id}")]
        [HttpDelete]
        public async Task<IActionResult> DeletePost(Guid id)
        {

            var command = new DeleteFoundPetPostCommand { Id = id };

            await _mediator.Send(command);

            return NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> Getall()
        {
            var query = new GetFoundPetPostsQuery();
            var result = await _mediator.Send(query);
            var mappedResult = _mapper.Map<List<FoundPetPostGetDto>>(result);
            return Ok(mappedResult);
        }

        /*[HttpGet]
        public async Task<IActionResult> Getall(object search)
        {
            var query = new GetFoundPetPostsSearchQuery(search);
            var result = await _mediator.Send(query);
            var mappedResult = _mapper.Map<List<FoundPetPostGetDto>>(result);
            return Ok(mappedResult);
        }*/


        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdatePost(Guid id, [FromBody] FoundPetPostPutPostDto updated)
        {
            var command = _mapper.Map<UpdateFoundPetPostCommand>(updated);
            command.Id = id;

            await _mediator.Send(command);

            return NoContent();
        }

    }
}
