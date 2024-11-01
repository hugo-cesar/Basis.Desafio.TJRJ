using Basis.Desafio.TJRJ.Domain.Features.Authors.Commands.Requests;
using Basis.Desafio.TJRJ.Domain.Features.Authors.Dtos;
using Basis.Desafio.TJRJ.Domain.Features.Authors.Queries.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Basis.Desafio.TJRJ.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<AuthorsController> _logger;

        public AuthorsController(IMediator mediator, ILogger<AuthorsController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(AuthorDto))]
        public async Task<ActionResult<AuthorDto>> Create([FromBody] AddAuthorRequest request)
        {
            var author = await _mediator.Send(request);

            return CreatedAtAction(nameof(GetById), new { id = author.Id }, author);
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AuthorDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(AuthorDto))]
        public async Task<ActionResult<AuthorDto>> Update(int id, [FromBody] UpdateAuthorRequest request)
        {
            request.SetId(id);
            var author = await _mediator.Send(request);

            if (author is null) return NotFound("Autor não encontrado.");

            return Ok(author);
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(AuthorDto))]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _mediator.Send(new DeleteAuthorRequest(id));

            if (deleted) return NoContent();

            return NotFound("Autor não encontrado.");
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AuthorDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(AuthorDto))]
        public async Task<ActionResult<AuthorDto>> GetById(int id)
        {
            var author = await _mediator.Send(new GetAuthorByIdRequest(id));

            if (author is null) return NotFound("Autor não encontrado.");

            return Ok(author);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<AuthorDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(IEnumerable<AuthorDto>))]
        public async Task<ActionResult<AuthorDto>> GetAll()
        {
            var list = await _mediator.Send(new ListAuthorRequest());

            if (list.Any()) return Ok(list);

            return NotFound();
        }
    }
}