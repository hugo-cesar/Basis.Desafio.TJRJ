using Basis.Desafio.TJRJ.Domain.Features.Authors.Commands.Requests;
using Basis.Desafio.TJRJ.Domain.Features.Authors.Commands.Validators;
using FluentValidation.TestHelper;

namespace Basis.Desafio.TJRJ.UnitTests.Validators.Authors;

public class UpdateAuthorRequestValidatorTests
{
    private readonly UpdateAuthorRequestValidator _validator;

    public UpdateAuthorRequestValidatorTests()
    {
        _validator = new UpdateAuthorRequestValidator();
    }

    [Fact]
    public void Should_Have_Error_When_Id_Is_Less_Than_Or_Equal_To_Zero()
    {
        var request = new UpdateAuthorRequest { Name = "Valid Name" };
        request.SetId(0);

        var result = _validator.TestValidate(request);
        result.ShouldHaveValidationErrorFor(a => a.Id);
    }

    [Fact]
    public void Should_Have_Error_When_Name_Is_Empty()
    {
        var request = new UpdateAuthorRequest { Name = "" };
        request.SetId(1);

        var result = _validator.TestValidate(request);
        result.ShouldHaveValidationErrorFor(a => a.Name);
    }

    [Fact]
    public void Should_Have_Error_When_Name_Exceeds_Max_Length()
    {
        var request = new UpdateAuthorRequest { Name = new string('a', 41) };
        request.SetId(1);

        var result = _validator.TestValidate(request);
        result.ShouldHaveValidationErrorFor(a => a.Name);
    }

    [Fact]
    public void Should_Not_Have_Error_When_Request_Is_Valid()
    {
        var request = new UpdateAuthorRequest { Name = "Valid Author Name" };
        request.SetId(1);

        var result = _validator.TestValidate(request);
        result.ShouldNotHaveAnyValidationErrors();
    }
}
