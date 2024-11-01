using Basis.Desafio.TJRJ.Domain.Features.Subjects.Commands.Requests;
using FluentValidation;

namespace Basis.Desafio.TJRJ.Domain.Features.Subjects.Commands.Validators;

public class UpdateSubjectRequestValidator : AbstractValidator<UpdateSubjectRequest>
{
    public UpdateSubjectRequestValidator()
    {
        RuleFor(item => item.Id)
           .GreaterThan(0);

        RuleFor(item => item.Description)
            .NotEmpty()
            .MaximumLength(20);
    }
}