using Basis.Desafio.TJRJ.Domain.Features.Authors.Commands.Requests;
using FluentValidation;

namespace Basis.Desafio.TJRJ.Domain.Features.Authors.Commands.Validators;

public class UpdateAuthorRequestValidator : AbstractValidator<UpdateAuthorRequest>
{
    public UpdateAuthorRequestValidator()
    {
        RuleFor(item => item.Id)
            .GreaterThan(0);

        RuleFor(item => item.Name)
            .NotEmpty()
            .MaximumLength(40);
    }
}