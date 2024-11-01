using Basis.Desafio.TJRJ.Domain.Features.Authors.Commands.Requests;
using Basis.Desafio.TJRJ.Domain.Features.Authors.Commands.Validators;
using FluentValidation.TestHelper;

namespace Basis.Desafio.TJRJ.UnitTests.Validators.Authors;

public class DeleteAuthorRequestValidatorTests
{
    private readonly DeleteAuthorRequestValidator _validator;

    public DeleteAuthorRequestValidatorTests()
    {
        _validator = new DeleteAuthorRequestValidator();
    }

    [Fact]
    public void Should_Have_Error_When_Id_Is_Less_Than_Or_Equal_To_Zero()
    {
        var request = new DeleteAuthorRequest(0);
        var result = _validator.TestValidate(request);
        result.ShouldHaveValidationErrorFor(a => a.Id);
    }

    [Fact]
    public void Should_Not_Have_Error_When_Id_Is_Valid()
    {
        var request = new DeleteAuthorRequest(1);
        var result = _validator.TestValidate(request);
        result.ShouldNotHaveAnyValidationErrors();
    }
}
