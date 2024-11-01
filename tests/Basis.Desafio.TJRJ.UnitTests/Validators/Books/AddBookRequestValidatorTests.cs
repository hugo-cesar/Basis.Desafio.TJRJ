using Basis.Desafio.TJRJ.Domain.Features.Books.Commands.Requests;
using Basis.Desafio.TJRJ.Domain.Features.Books.Commands.Validators;
using FluentValidation.TestHelper;

namespace Basis.Desafio.TJRJ.UnitTests.Validators.Books;

public class AddBookRequestValidatorTests
{
    private readonly AddBookRequestValidator _validator;

    public AddBookRequestValidatorTests()
    {
        _validator = new AddBookRequestValidator();
    }

    [Fact]
    public void Should_Have_Error_When_Title_Is_Empty()
    {
        var request = new AddBookRequest { Title = "", Publisher = "Publisher", Edition = 1, PublicationYear = "2024" };
        var result = _validator.TestValidate(request);
        result.ShouldHaveValidationErrorFor(b => b.Title);
    }

    [Fact]
    public void Should_Have_Error_When_Publisher_Is_Empty()
    {
        var request = new AddBookRequest { Title = "Title", Publisher = "", Edition = 1, PublicationYear = "2024" };
        var result = _validator.TestValidate(request);
        result.ShouldHaveValidationErrorFor(b => b.Publisher);
    }

    [Fact]
    public void Should_Have_Error_When_Edition_Is_Less_Than_Or_Equal_To_Zero()
    {
        var request = new AddBookRequest { Title = "Title", Publisher = "Publisher", Edition = 0, PublicationYear = "2024" };
        var result = _validator.TestValidate(request);
        result.ShouldHaveValidationErrorFor(b => b.Edition);
    }

    [Fact]
    public void Should_Have_Error_When_PublicationYear_Is_Empty()
    {
        var request = new AddBookRequest { Title = "Title", Publisher = "Publisher", Edition = 1, PublicationYear = "" };
        var result = _validator.TestValidate(request);
        result.ShouldHaveValidationErrorFor(b => b.PublicationYear);
    }

    [Fact]
    public void Should_Have_Error_When_Authors_Are_Empty()
    {
        var request = new AddBookRequest { Title = "Title", Publisher = "Publisher", Edition = 1, PublicationYear = "2024", Authors = new List<int>() };
        var result = _validator.TestValidate(request);
        result.ShouldHaveValidationErrorFor(b => b.Authors);
    }

    [Fact]
    public void Should_Have_Error_When_Author_Id_Is_Zero()
    {
        var request = new AddBookRequest { Title = "Title", Publisher = "Publisher", Edition = 1, PublicationYear = "2024", Authors = new List<int> { 0 } };
        var result = _validator.TestValidate(request);
        result.ShouldHaveValidationErrorFor(b => b.Authors);
    }

    [Fact]
    public void Should_Not_Have_Error_When_Request_Is_Valid()
    {
        var request = new AddBookRequest
        {
            Title = "Title",
            Publisher = "Publisher",
            Edition = 1,
            PublicationYear = "2024",
            Authors = new List<int> { 1 },
            Subjects = new List<int> { 1 },
        };
        var result = _validator.TestValidate(request);
        result.ShouldNotHaveAnyValidationErrors();
    }
}