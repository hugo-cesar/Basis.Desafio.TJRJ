using Basis.Desafio.TJRJ.Domain.Features.Authors.Commands.Requests;
using FluentValidation;

namespace Basis.Desafio.TJRJ.Domain.Features.Authors.Commands.Validators;

public class AddAuthorRequestValidator : AbstractValidator<AddAuthorRequest>
{
    public AddAuthorRequestValidator()
    {
        RuleFor(item => item.Name).NotEmpty();
    }
}