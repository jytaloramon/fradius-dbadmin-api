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
                .GreaterThan(0).WithMessage("Temp Message");
        });

        RuleSet("Username", () =>
        {
            RuleFor(attribute => attribute.Username)
                .NotEmpty().WithMessage("Temp Message")
                .MaximumLength(64).WithMessage("Temp Message")
                .Matches(RegularExpression.Username).WithMessage("Temp Message");
        });

        RuleSet("Attribute", () =>
        {
            RuleFor(attribute => attribute.Attribute)
                .NotEmpty().WithMessage("Temp Message")
                .MaximumLength(64).WithMessage("Temp Message")
                .Matches(RegularExpression.WordWithoutWhiteSpace).WithMessage("Temp Message");
        });

        RuleSet("Operation", () =>
        {
            RuleFor(attribute => attribute.Operation)
                .NotEmpty().WithMessage("Temp Message")
                .MaximumLength(64).WithMessage("Temp Message")
                .Matches(RegularExpression.WordWithoutWhiteSpace).WithMessage("Temp Message");
        });

        RuleSet("Value", () =>
        {
            RuleFor(attribute => attribute.Value)
                .NotEmpty().WithMessage("Temp Message")
                .MaximumLength(64).WithMessage("Temp Message")
                .Matches(RegularExpression.WordWithoutWhiteSpace).WithMessage("Temp Message");
        });
    }
}