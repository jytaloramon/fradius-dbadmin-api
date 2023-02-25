using Common.Utils;
using FluentValidation;

namespace FradiusDomain.Admin.Entities.Validations;

public class AdminUserValidator : AbstractValidator<AdminUser>
{
    public AdminUserValidator()
    {
        RuleSet("Id", () =>
        {
            RuleFor(admin => admin.Id)
                .GreaterThan(0).WithMessage("Temp Message");
        });

        RuleSet("FirstName", () =>
        {
            RuleFor(admin => admin.FirstName)
                .NotEmpty().WithMessage("Temp Message")
                .MaximumLength(64).WithMessage("Temp Message")
                .Matches(RegularExpression.CommonName).WithMessage("Temp Message");
        });

        RuleSet("LastName", () =>
        {
            RuleFor(admin => admin.LastName)
                .NotEmpty().WithMessage("Temp Message")
                .MaximumLength(64).WithMessage("Temp Message")
                .Matches(RegularExpression.CommonName).WithMessage("Temp Message");
        });

        RuleSet("Username", () =>
        {
            RuleFor(admin => admin.Username)
                .NotEmpty().WithMessage("Temp Message")
                .MaximumLength(32).WithMessage("Temp Message")
                .Matches(RegularExpression.Username).WithMessage("Temp Message");
        });

        RuleSet("Email", () =>
        {
            RuleFor(admin => admin.Email)
                .MaximumLength(64).WithMessage("Temp Message")
                .EmailAddress().WithMessage("Temp Message");
        });

        RuleSet("Password", () =>
        {
            RuleFor(admin => admin.Password)
                .MinimumLength(8).WithMessage("Temp Message")
                .MaximumLength(32).WithMessage("Temp Message");
        });

        RuleSet("ProfileImage", () =>
        {
            RuleFor(admin => admin.ProfileImage)
                .MaximumLength(64).WithMessage("Temp Message")
                .Matches(RegularExpression.GeneralUseName).WithMessage("Temp Message");
        });
    }
}