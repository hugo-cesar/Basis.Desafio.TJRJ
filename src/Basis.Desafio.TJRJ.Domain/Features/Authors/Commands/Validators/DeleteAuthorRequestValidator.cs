using Basis.Desafio.TJRJ.Domain.Features.Authors.Commands.Requests;
using FluentValidation;

namespace Basis.Desafio.TJRJ.Domain.Features.Authors.Commands.Validators;

public class DeleteAuthorRequestValidator : AbstractValidator<DeleteAuthorRequest>
{
    public DeleteAuthorRequestValidator()
    {
        RuleFor(item => item.Id)
            .GreaterThan(0);
    }
}