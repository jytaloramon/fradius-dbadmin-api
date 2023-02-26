using FluentValidation;
using FradiusDomain.Admin.Entities;
using FradiusDomain.Admin.EntitiesFactories;
using Common.Exceptions;

namespace FradiusDomainUnitTests.Admin.EntitiesFactories;

public class AdminUserFactoryUnitTests
{
    [Theory]
    [InlineData("Mike", "Ross", "mikeusername", "15235346", "mike@ross", "")]
    [InlineData("Mike", "Ross", "mikeusername", "15235346", "mike@ross", null)]
    public void ValidCreate(string fistName, string lastName, string username, string password,
        string email, string? profileImage)
    {
        var validator = new InlineValidator<AdminUser>();
        validator.RuleFor(admin => admin.FirstName).Must(fistName => true);
        validator.RuleFor(admin => admin.LastName).Must(lastName => true);
        validator.RuleFor(admin => admin.Username).Must(username => true);
        validator.RuleFor(admin => admin.Password).Must(password => true);
        validator.RuleFor(admin => admin.Email).Must(email => true);
        validator.RuleFor(admin => admin.ProfileImage).Must(profileImage => true);

        var factory = new AdminUserFactory(validator);
        var adminUser = factory.Create(fistName, lastName, username, password, email, profileImage);

        Assert.Equal(
            new List<object>()
            {
                fistName, lastName, username, password, email, string.IsNullOrEmpty(profileImage) ? null : profileImage
            },
            new List<object>()
            {
                adminUser.FirstName, adminUser.LastName, adminUser.Username, adminUser.Password, adminUser.Email,
                adminUser.ProfileImage,
            });
    }

    [Fact]
    public void InvalidCreateAllProperty()
    {
        var validator = new InlineValidator<AdminUser>();
        validator.RuleFor(admin => admin.FirstName).Must(fistName => false);
        validator.RuleFor(admin => admin.LastName).Must(lastName => false);
        validator.RuleFor(admin => admin.Username).Must(username => false);
        validator.RuleFor(admin => admin.Password).Must(password => false);
        validator.RuleFor(admin => admin.Email).Must(email => false);
        validator.RuleFor(admin => admin.ProfileImage).Must(profileImage => false);

        var factory = new AdminUserFactory(validator);

        var exception = Assert.Throws<EntityValidationException>(() => { factory.Create("", "", "", "", "", ""); });

        Assert.Equal(6, exception.Errors.Count);
    }
}