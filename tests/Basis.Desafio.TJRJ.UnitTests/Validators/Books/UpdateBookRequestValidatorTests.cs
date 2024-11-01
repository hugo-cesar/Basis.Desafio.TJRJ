using Basis.Desafio.TJRJ.Domain.Features.Books.Commands.Requests;
using Basis.Desafio.TJRJ.Domain.Features.Books.Commands.Validators;
using FluentValidation.TestHelper;

namespace Basis.Desafio.TJRJ.UnitTests.Validators.Books;

public class UpdateBookRequestValidatorTests
{
    private readonly UpdateBookRequestValidator _validator;

    public UpdateBookRequestValidatorTests()
    {
        _validator = new UpdateBookRequestValidator();
    }

    [Fact]
    public void Should_Have_Error_When_Id_Is_Less_Than_Or_Equal_To_Zero()
    {
        var request = new UpdateBookRequest {  Title = "Title", Publisher = "Publisher", Edition = 1, PublicationYear = "2024" };
        request.SetId(0);
        
        var result = _validator.TestValidate(request);
        result.ShouldHaveValidationErrorFor(b => b.Id);
    }

    [Fact]
    public void Should_Have_Error_When_Title_Is_Empty()
    {
        var request = new UpdateBookRequest {  Title = "", Publisher = "Publisher", Edition = 1, PublicationYear = "2024" };
        request.SetId(1);
        
        var result = _validator.TestValidate(request);
        result.ShouldHaveValidationErrorFor(b => b.Title);
    }

    [Fact]
    public void Should_Have_Error_When_Publisher_Is_Empty()
    {
        var request = new UpdateBookRequest { Title = "Title", Publisher = "", Edition = 1, PublicationYear = "2024" };
        request.SetId(1);
       
        var result = _validator.TestValidate(request);
        result.ShouldHaveValidationErrorFor(b => b.Publisher);
    }

    [Fact]
    public void Should_Have_Error_When_Edition_Is_Less_Than_Or_Equal_To_Zero()
    {
        var request = new UpdateBookRequest {  Title = "Title", Publisher = "Publisher", Edition = 0, PublicationYear = "2024" };
        request.SetId(1);

        var result = _validator.TestValidate(request);
        result.ShouldHaveValidationErrorFor(b => b.Edition);
    }

    [Fact]
    public void Should_Have_Error_When_PublicationYear_Is_Empty()
    {
        var request = new UpdateBookRequest {  Title = "Title", Publisher = "Publisher", Edition = 1, PublicationYear = "" };
        request.SetId(1);

        var result = _validator.TestValidate(request);
        result.ShouldHaveValidationErrorFor(b => b.PublicationYear);
    }

    [Fact]
    public void Should_Have_Error_When_Authors_Are_Empty()
    {
        var request = new UpdateBookRequest {  Title = "Title", Publisher = "Publisher", Edition = 1, PublicationYear = "2024", Authors = new List<int>() };
        request.SetId(1);

        var result = _validator.TestValidate(request);
        result.ShouldHaveValidationErrorFor(b => b.Authors);
    }

    [Fact]
    public void Should_Have_Error_When_Author_Id_Is_Zero()
    {
        var request = new UpdateBookRequest {  Title = "Title", Publisher = "Publisher", Edition = 1, PublicationYear = "2024", Authors = new List<int> { 0 } };
        request.SetId(1);

        var result = _validator.TestValidate(request);
        result.ShouldHaveValidationErrorFor(b => b.Authors);
    }

    [Fact]
    public void Should_Not_Have_Error_When_Request_Is_Valid()
    {
        var request = new UpdateBookRequest
        {
            Title = "Title",
            Publisher = "Publisher",
            Edition = 1,
            PublicationYear = "2024",
            Authors = new List<int> { 1 },
            Subjects = new List<int> { 1 },
        };

        request.SetId(1);

        var result = _validator.TestValidate(request);
        result.ShouldNotHaveAnyValidationErrors();
    }
}
