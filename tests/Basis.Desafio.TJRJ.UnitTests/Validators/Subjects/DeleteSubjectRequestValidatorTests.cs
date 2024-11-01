using Basis.Desafio.TJRJ.Domain.Features.Subjects.Commands.Requests;
using Basis.Desafio.TJRJ.Domain.Features.Subjects.Commands.Validators;
using FluentValidation.TestHelper;

namespace Basis.Desafio.TJRJ.UnitTests.Validators.Subjects;

public class DeleteSubjectRequestValidatorTests
{
    private readonly DeleteSubjectRequestValidator _validator;

    public DeleteSubjectRequestValidatorTests()
    {
        _validator = new DeleteSubjectRequestValidator();
    }

    [Fact]
    public void Should_Have_Error_When_Id_Is_Less_Than_Or_Equal_To_Zero()
    {
        var request = new DeleteSubjectRequest(0);
        var result = _validator.TestValidate(request);
        result.ShouldHaveValidationErrorFor(s => s.Id);
    }

    [Fact]
    public void Should_Not_Have_Error_When_Id_Is_Valid()
    {
        var request = new DeleteSubjectRequest(1);
        var result = _validator.TestValidate(request);
        result.ShouldNotHaveAnyValidationErrors();
    }
}
