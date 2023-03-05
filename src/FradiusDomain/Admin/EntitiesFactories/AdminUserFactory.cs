using Common.Exceptions;
using FluentValidation;
using FradiusDomain.Admin.Entities;
using FradiusDomain.Admin.EntitiesFactories.Interfaces;

namespace FradiusDomain.Admin.EntitiesFactories;

public class AdminUserFactory : IAdminUserFactory
{
    private readonly AbstractValidator<AdminUser> _validator;

    public AdminUserFactory(AbstractValidator<AdminUser> validator)
    {
        _validator = validator;
    }

    public AdminUser Create(int id)
    {
        var adminUser = new AdminUser { Id = id };

        Validate(adminUser, "Id");

        return adminUser;
    }

    public AdminUser Create(string fistName, string lastName, string username, string password, string email,
        string? profileImage, bool isActive)
    {
        var adminUser = new AdminUser
        {
            FirstName = fistName,
            LastName = lastName,
            Username = username,
            Password = password,
            Email = email,
            ProfileImage = string.IsNullOrWhiteSpace(profileImage) ? null : profileImage,
            IsActive = isActive
        };

        Validate(adminUser, "FirstName", "LastName", "Username", "Password", "Email", "ProfileImage");

        return adminUser;
    }

    private void Validate(AdminUser adminUser, params string[] ruleSets)
    {
        var result = _validator.Validate(adminUser, strategy => strategy.IncludeRuleSets(ruleSets));

        if (!result.IsValid)
        {
            throw new EntityValidationException(result.ToDictionary());
        }
    }
}