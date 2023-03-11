using Common.Utils;
using FluentValidation;

namespace RadiusDomain.User.Entities.Validations;

public class UserAttributeValidator : AbstractValidator<UserAttribute>
{
    public UserAttributeValidator()
    {
        RuleSet("Id", () =>
        {
            RuleFor(attribute => attribute.Id)
                .GreaterThan(0).WithMessage("Value must be greater than 0.");
        });

        RuleSet("Username", () =>
        {
            RuleFor(attribute => attribute.Username)
                .NotEmpty().WithMessage("Required field.")
                .MaximumLength(64).WithMessage("Maximum size is 64.")
                .Matches(RegularExpression.Username).WithMessage("Invalid format.");
        });

        RuleSet("Attribute", () =>
        {
            RuleFor(attribute => attribute.Attribute)
                .NotEmpty().WithMessage("Required field.")
                .MaximumLength(64).WithMessage("Maximum size is 64.")
                .Matches(RegularExpression.WordWithoutWhiteSpace).WithMessage("Invalid format.");
        });

        RuleSet("Operation", () =>
        {
            RuleFor(attribute => attribute.Operation)
                .NotEmpty().WithMessage("Required field.")
                .MaximumLength(64).WithMessage("Maximum size is 64.")
                .Matches(RegularExpression.WordWithoutWhiteSpace).WithMessage("Invalid format.");
        });

        RuleSet("Value", () =>
        {
            RuleFor(attribute => attribute.Value)
                .NotEmpty().WithMessage("Required field.")
                .MaximumLength(64).WithMessage("Maximum size is 64.")
                .Matches(RegularExpression.WordWithoutWhiteSpace).WithMessage("Invalid format.");
        });
    }
}