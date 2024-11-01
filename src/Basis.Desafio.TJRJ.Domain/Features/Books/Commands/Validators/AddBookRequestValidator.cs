using Basis.Desafio.TJRJ.Domain.Features.Books.Commands.Requests;
using FluentValidation;

namespace Basis.Desafio.TJRJ.Domain.Features.Books.Commands.Validators;

public class AddBookRequestValidator : AbstractValidator<AddBookRequest>
{
    public AddBookRequestValidator()
    {

        RuleFor(book => book.Title)
            .NotEmpty()
            .MaximumLength(100);

        RuleFor(book => book.Publisher)
            .NotEmpty()
            .MaximumLength(50);

        RuleFor(book => book.Edition)
            .GreaterThan(0);

        RuleFor(book => book.PublicationYear)
            .NotEmpty()
            .Matches(@"^\d{4}$").WithMessage("O ano de publicação deve ter 4 dígitos.");

        RuleFor(book => book.Authors)
            .NotEmpty();

        RuleForEach(book => book.Authors)
            .GreaterThan(0).WithMessage("Cada autor deve ter um ID maior que 0.");

        RuleFor(book => book.Subjects)
           .NotEmpty();

        RuleForEach(book => book.Subjects)
          .GreaterThan(0).WithMessage("Cada assunto deve ter um ID maior que 0.");

        RuleForEach(book => book.PurchaseTypes)
            .ChildRules(purchaseType =>
            {
                purchaseType.RuleFor(pt => pt.Id).GreaterThan(0).WithMessage("Cada tipo de compra deve ter um ID maior que 0."); ;

                purchaseType.RuleFor(pt => pt.Price)
                    .GreaterThan(0).WithMessage("O preço deve ser maior que zero.");
            });
    }
}