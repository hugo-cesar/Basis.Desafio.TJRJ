using Basis.Desafio.TJRJ.Domain.Features.Subjects.Commands.Requests;
using Basis.Desafio.TJRJ.Domain.Features.Subjects.Commands.Validators;
using FluentValidation.TestHelper;

namespace Basis.Desafio.TJRJ.UnitTests.Validators.Subjects;

public class AddSubjectRequestValidatorTests
{
    private readonly AddSubjectRequestValidator _validator;

    public AddSubjectRequestValidatorTests()
    {
        _validator = new AddSubjectRequestValidator();
    }

    [Fact]
    public void Should_Have_Error_When_Description_Is_Empty()
    {
        var request = new AddSubjectRequest { Description = "" };
        var result = _validator.TestValidate(request);
        result.ShouldHaveValidationErrorFor(s => s.Description);
    }

    [Fact]
    public void Should_Have_Error_When_Description_Exceeds_Max_Length()
    {
        var request = new AddSubjectRequest { Description = new string('a', 21) }; // 21 characters
        var result = _validator.TestValidate(request);
        result.ShouldHaveValidationErrorFor(s => s.Description);
    }

    [Fact]
    public void Should_Not_Have_Error_When_Description_Is_Valid()
    {
        var request = new AddSubjectRequest { Description = "Valid Description" };
        var result = _validator.TestValidate(request);
        result.ShouldNotHaveAnyValidationErrors();
    }
}