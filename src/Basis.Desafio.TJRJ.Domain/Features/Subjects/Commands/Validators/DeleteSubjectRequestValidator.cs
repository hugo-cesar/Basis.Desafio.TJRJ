using Basis.Desafio.TJRJ.Domain.Features.Subjects.Commands.Requests;
using FluentValidation;

namespace Basis.Desafio.TJRJ.Domain.Features.Subjects.Commands.Validators;

public class DeleteSubjectRequestValidator : AbstractValidator<DeleteSubjectRequest>
{
    public DeleteSubjectRequestValidator()
    {
        RuleFor(item => item.Id)
           .GreaterThan(0);
    }
}