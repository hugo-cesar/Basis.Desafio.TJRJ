using Basis.Desafio.TJRJ.Domain.Features.Books.Commands.Requests;
using Basis.Desafio.TJRJ.Domain.Features.Books.Dtos;
using Basis.Desafio.TJRJ.Domain.Features.Books.Queries.Requests;
using Basis.Desafio.TJRJ.Domain.Features.Relatorios.Dtos;
using Basis.Desafio.TJRJ.Domain.Features.Relatorios.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Basis.Desafio.TJRJ.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<BooksController> _logger;

        public BooksController(IMediator mediator, ILogger<BooksController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(BookDto))]
        public async Task<ActionResult<BookDto>> Create([FromBody] AddBookRequest request)
        {
            var book = await _mediator.Send(request);

            return CreatedAtAction(nameof(GetById), new { id = book.Id }, book);
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BookDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(BookDto))]
        public async Task<ActionResult<BookDto>> Update(int id, [FromBody] UpdateBookRequest request)
        {
            request.SetId(id);
            var book = await _mediator.Send(request);

            if (book is null) return NotFound("Book não encontrado.");

            return Ok(book);
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(BookDto))]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _mediator.Send(new DeleteBookRequest(id));

            if (deleted) return NoContent();

            return NotFound("Livro não encontrado.");
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BookDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(BookDto))]
        public async Task<ActionResult<BookDto>> GetById(int id)
        {
            var book = await _mediator.Send(new GetBookByIdRequest(id));

            if (book is null) return NotFound("Livro não encontrado.");

            return Ok(book);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<BookDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(IEnumerable<BookDto>))]
        public async Task<ActionResult<BookDto>> GetAll()
        {
            var list = await _mediator.Send(new ListBookRequest());

            if (list.Any()) return Ok(list);

            return NotFound();
        }

        [HttpGet("purchase-types")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<BookPurchaseTypeDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(IEnumerable<BookPurchaseTypeDto>))]
        public async Task<ActionResult<BookPurchaseTypeDto>> GetPurchaseTypes()
        {
            var list = await _mediator.Send(new ListPurchaseTypesRequest());

            if (list.Any()) return Ok(list);

            return NotFound();
        }

        [HttpGet("report")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<ReportDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(IEnumerable<ReportDto>))]
        public async Task<ActionResult<ReportDto>> Report()
        {
            var report = await _mediator.Send(new GetReportRequest());

            if(report is null) return NotFound();

            return Ok(report);
        }
    }
}