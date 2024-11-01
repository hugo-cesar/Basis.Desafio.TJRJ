using Basis.Desafio.TJRJ.Domain.Features.Subjects.Commands.Requests;
using Basis.Desafio.TJRJ.Domain.Features.Subjects.Dtos;
using Basis.Desafio.TJRJ.Domain.Features.Subjects.Queries.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Basis.Desafio.TJRJ.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SubjectsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<SubjectsController> _logger;

        public SubjectsController(IMediator mediator, ILogger<SubjectsController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(SubjectDto))]
        public async Task<ActionResult<SubjectDto>> Create([FromBody] AddSubjectRequest request)
        {
            var subject = await _mediator.Send(request);

            return CreatedAtAction(nameof(GetById), new { id = subject.Id }, subject);
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SubjectDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(SubjectDto))]
        public async Task<ActionResult<SubjectDto>> Update(int id, [FromBody] UpdateSubjectRequest request)
        {
            request.SetId(id);
            var subject = await _mediator.Send(request);

            if (subject is null) return NotFound("Assunto não encontrado.");

            return Ok(subject);
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(SubjectDto))]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _mediator.Send(new DeleteSubjectRequest(id));

            if (deleted) return NoContent();

            return NotFound("Assunto não encontrado.");
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SubjectDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(SubjectDto))]
        public async Task<ActionResult<SubjectDto>> GetById(int id)
        {
            var subject = await _mediator.Send(new GetSubjectByIdRequest(id));

            if (subject is null) return NotFound("Assunto não encontrado.");

            return Ok(subject);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<SubjectDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(IEnumerable<SubjectDto>))]
        public async Task<ActionResult<SubjectDto>> GetAll()
        {
            var list = await _mediator.Send(new ListSubjectRequest());

            if (list.Any()) return Ok(list);

            return NotFound();
        }
    }
}