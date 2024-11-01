using Basis.Desafio.TJRJ.Domain.Features.Books.Commands.Requests;
using Basis.Desafio.TJRJ.Domain.Features.Books.Commands.Validators;
using FluentValidation.TestHelper;

namespace Basis.Desafio.TJRJ.UnitTests.Validators.Books;

public class DeleteBookRequestValidatorTests
{
    private readonly DeleteBookRequestValidator _validator;

    public DeleteBookRequestValidatorTests()
    {
        _validator = new DeleteBookRequestValidator();
    }

    [Fact]
    public void Should_Have_Error_When_Id_Is_Less_Than_Or_Equal_To_Zero()
    {
        var request = new DeleteBookRequest(0);
        var result = _validator.TestValidate(request);
        result.ShouldHaveValidationErrorFor(b => b.Id);
    }

    [Fact]
    public void Should_Not_Have_Error_When_Id_Is_Valid()
    {
        var request = new DeleteBookRequest(1);
        var result = _validator.TestValidate(request);
        result.ShouldNotHaveAnyValidationErrors();
    }
}
