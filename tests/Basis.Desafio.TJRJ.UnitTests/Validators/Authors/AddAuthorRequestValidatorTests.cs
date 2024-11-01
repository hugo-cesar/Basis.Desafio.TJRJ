using Basis.Desafio.TJRJ.Domain.Features.Authors.Commands.Requests;
using Basis.Desafio.TJRJ.Domain.Features.Authors.Commands.Validators;
using FluentValidation.TestHelper;

namespace Basis.Desafio.TJRJ.UnitTests.Validators.Authors;

public class AddAuthorRequestValidatorTests
{
    private readonly AddAuthorRequestValidator _validator;

    public AddAuthorRequestValidatorTests()
    {
        _validator = new AddAuthorRequestValidator();
    }

    [Fact]
    public void Should_Have_Error_When_Name_Is_Empty()
    {
        var request = new AddAuthorRequest { Name = "" };
        var result = _validator.TestValidate(request);
        result.ShouldHaveValidationErrorFor(a => a.Name);
    }

    [Fact]
    public void Should_Have_Error_When_Name_Exceeds_Max_Length()
    {
        var request = new AddAuthorRequest { Name = new string('a', 41) };
        var result = _validator.TestValidate(request);
        result.ShouldHaveValidationErrorFor(a => a.Name);
    }

    [Fact]
    public void Should_Not_Have_Error_When_Name_Is_Valid()
    {
        var request = new AddAuthorRequest { Name = "Valid Author Name" };
        var result = _validator.TestValidate(request);
        result.ShouldNotHaveAnyValidationErrors();
    }
}
