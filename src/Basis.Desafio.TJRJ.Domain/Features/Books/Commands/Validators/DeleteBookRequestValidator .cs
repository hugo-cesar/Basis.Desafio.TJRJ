using Basis.Desafio.TJRJ.Domain.Features.Books.Commands.Requests;
using FluentValidation;

namespace Basis.Desafio.TJRJ.Domain.Features.Books.Commands.Validators;

public class DeleteBookRequestValidator : AbstractValidator<DeleteBookRequest>
{
    public DeleteBookRequestValidator()
    {
        RuleFor(book => book.Id)
            .GreaterThan(0);
    }
}
