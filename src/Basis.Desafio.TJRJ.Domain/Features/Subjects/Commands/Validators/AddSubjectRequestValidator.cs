using Basis.Desafio.TJRJ.Domain.Features.Subjects.Commands.Requests;
using FluentValidation;

namespace Basis.Desafio.TJRJ.Domain.Features.Subjects.Commands.Validators;

public class AddSubjectRequestValidator : AbstractValidator<AddSubjectRequest>
{
    public AddSubjectRequestValidator()
    {
        RuleFor(item => item.Description)
            .NotEmpty()
            .MaximumLength(20);
    }
}