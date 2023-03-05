using FluentValidation;
using FradiusDomain.Admin.Entities;
using FradiusDomain.Admin.EntitiesFactories;
using Common.Exceptions;

namespace FradiusDomainUnitTests.Admin.EntitiesFactories;

public class AdminUserFactoryUnitTests
{
    private readonly AbstractValidator<AdminUser> _validatorAllTrue;

    private readonly AbstractValidator<AdminUser> _validatorAllFalse;

    public AdminUserFactoryUnitTests()
    {
        _validatorAllTrue = new InlineValidator<AdminUser>();
        _validatorAllTrue.RuleSet("Id",
            () => _validatorAllTrue.RuleFor(user => user.Id).Must(_ => true));
        _validatorAllTrue.RuleSet("FirstName",
            () => _validatorAllTrue.RuleFor(user => user.FirstName).Must(_ => true));
        _validatorAllTrue.RuleSet("LastName",
            () => _validatorAllTrue.RuleFor(user => user.LastName).Must(_ => true));
        _validatorAllTrue.RuleSet("Username",
            () => _validatorAllTrue.RuleFor(user => user.Username).Must(_ => true));
        _validatorAllTrue.RuleSet("Email",
            () => _validatorAllTrue.RuleFor(user => user.Email).Must(_ => true));
        _validatorAllTrue.RuleSet("Password",
            () => _validatorAllTrue.RuleFor(user => user.Password).Must(_ => true));
        _validatorAllTrue.RuleSet("ProfileImage",
            () => _validatorAllTrue.RuleFor(user => user.ProfileImage).Must(_ => true));
        _validatorAllTrue.RuleSet("CreateAt",
            () => _validatorAllTrue.RuleFor(user => user.CreateAt).Must(_ => true));
        _validatorAllTrue.RuleSet("UpdateAt",
            () => _validatorAllTrue.RuleFor(user => user.UpdateAt).Must(_ => true));

        _validatorAllFalse = new InlineValidator<AdminUser>();
        _validatorAllFalse.RuleSet("Id",
            () => _validatorAllFalse.RuleFor(user => user.Id).Must(_ => false));
        _validatorAllFalse.RuleSet("FirstName",
            () => _validatorAllFalse.RuleFor(user => user.FirstName).Must(_ => false));
        _validatorAllFalse.RuleSet("LastName",
            () => _validatorAllFalse.RuleFor(user => user.LastName).Must(_ => false));
        _validatorAllFalse.RuleSet("Username",
            () => _validatorAllFalse.RuleFor(user => user.Username).Must(_ => false));
        _validatorAllFalse.RuleSet("Email",
            () => _validatorAllFalse.RuleFor(user => user.Email).Must(_ => false));
        _validatorAllFalse.RuleSet("Password",
            () => _validatorAllFalse.RuleFor(user => user.Password).Must(_ => false));
        _validatorAllFalse.RuleSet("ProfileImage",
            () => _validatorAllFalse.RuleFor(user => user.ProfileImage).Must(_ => false));
        _validatorAllFalse.RuleSet("CreateAt",
            () => _validatorAllFalse.RuleFor(user => user.CreateAt).Must(_ => false));
        _validatorAllFalse.RuleSet("UpdateAt",
            () => _validatorAllFalse.RuleFor(user => user.UpdateAt).Must(_ => false));
    }

    [Fact]
    public void Create_IdOnly_ReturnAdminUser()
    {
        var factory = new AdminUserFactory(_validatorAllTrue);

        var userActual = factory.Create(1);

        Assert.Equal(1, userActual.Id);
    }

    [Fact]
    public void Create_IdOnly_ThrowEntityValidationException()
    {
        var factory = new AdminUserFactory(_validatorAllFalse);

        var exceptionActual = Assert.Throws<EntityValidationException>(
            () => factory.Create(1));

        Assert.True(exceptionActual.Errors.ContainsKey("Id"));
        Assert.Equal(1, exceptionActual.Errors.Count);
    }

    [Fact]
    public void Create_SevenParameters_ReturnAdminUser()
    {
        var factory = new AdminUserFactory(_validatorAllTrue);

        var userActual = factory.Create("fistName", "lastName", "username",
            "password", "email", "profileImage", true);

        Assert.NotNull(userActual);
    }

    [Fact]
    public void Create_SevenParameters_ThrowEntityValidationException()
    {
        var factory = new AdminUserFactory(_validatorAllFalse);

        var exceptionActual = Assert.Throws<EntityValidationException>(
            () => factory.Create("fistName", "lastName", "username",
                "password", "email", "profileImage", true));
        
        Assert.True(exceptionActual.Errors.ContainsKey("FirstName"));
        Assert.True(exceptionActual.Errors.ContainsKey("LastName"));
        Assert.True(exceptionActual.Errors.ContainsKey("Username"));
        Assert.True(exceptionActual.Errors.ContainsKey("Password"));
        Assert.True(exceptionActual.Errors.ContainsKey("Email"));
        Assert.True(exceptionActual.Errors.ContainsKey("ProfileImage"));
        Assert.Equal(6, exceptionActual.Errors.Count);
    }
}