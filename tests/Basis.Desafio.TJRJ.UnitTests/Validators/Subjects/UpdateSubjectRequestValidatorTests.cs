using Basis.Desafio.TJRJ.Domain.Features.Subjects.Commands.Requests;
using Basis.Desafio.TJRJ.Domain.Features.Subjects.Commands.Validators;
using FluentValidation.TestHelper;

namespace Basis.Desafio.TJRJ.UnitTests.Validators.Subjects;

public class UpdateSubjectRequestValidatorTests
{
    private readonly UpdateSubjectRequestValidator _validator;

    public UpdateSubjectRequestValidatorTests()
    {
        _validator = new UpdateSubjectRequestValidator();
    }

    [Fact]
    public void Should_Have_Error_When_Id_Is_Less_Than_Or_Equal_To_Zero()
    {
        var request = new UpdateSubjectRequest { Description = "Valid Description" };
        request.SetId(0);

        var result = _validator.TestValidate(request);
        result.ShouldHaveValidationErrorFor(s => s.Id);
    }

    [Fact]
    public void Should_Have_Error_When_Description_Is_Empty()
    {
        var request = new UpdateSubjectRequest { Description = "" };
        request.SetId(1);

        var result = _validator.TestValidate(request);
        result.ShouldHaveValidationErrorFor(s => s.Description);
    }

    [Fact]
    public void Should_Have_Error_When_Description_Exceeds_Max_Length()
    {
        var request = new UpdateSubjectRequest { Description = new string('a', 21) };
        request.SetId(1);

        var result = _validator.TestValidate(request);
        result.ShouldHaveValidationErrorFor(s => s.Description);
    }

    [Fact]
    public void Should_Not_Have_Error_When_Request_Is_Valid()
    {
        var request = new UpdateSubjectRequest { Description = "Valid Description" };
        request.SetId(1);

        var result = _validator.TestValidate(request);
        result.ShouldNotHaveAnyValidationErrors();
    }
}

