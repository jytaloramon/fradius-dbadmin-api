using FluentValidation.Internal;
using FluentValidation.TestHelper;
using FradiusDomain.Admin.Entities;
using FradiusDomain.Admin.Entities.Validations;

namespace FradiusDomainUnitTests.Admin.Entities.Validations;

public class AdminUserValidatorUnitTest
{
    private readonly AdminUserValidator _validator = new AdminUserValidator();

    private void SetPropertyValidator(ValidationStrategy<AdminUser> opt, string property)
    {
        opt.IncludeRuleSets(property);
    }

    private TestValidationResult<AdminUser> RunValidator(AdminUser adminUser, string property)
    {
        return _validator.TestValidate(adminUser,
            opt => SetPropertyValidator(opt, property));
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    [InlineData(-50000)]
    public void InvalidIdLessThanOne(int id)
    {
        var adminUser = new AdminUser { Id = id };
        var result = RunValidator(adminUser, "Id");

        result.ShouldHaveValidationErrorFor(admin => admin.Id).WithErrorMessage("Temp Message");
    }

    [Theory]
    [InlineData(1)]
    [InlineData(10)]
    [InlineData(50000)]
    public void ValidId(int id)
    {
        var adminUser = new AdminUser { Id = id };
        var result = RunValidator(adminUser, "Id");

        result.ShouldNotHaveValidationErrorFor(admin => admin.Id);
    }

    [Fact]
    public void InvalidFirstNameEmpty()
    {
        var adminUser = new AdminUser { FirstName = "" };
        var result = RunValidator(adminUser, "FirstName");

        result.ShouldHaveValidationErrorFor(admin => admin.FirstName).WithErrorMessage("Temp Message");
    }

    [Theory]
    [InlineData("Mike Ross Josép Mike Ross Josép Mike Ross Josép Mike Ross Joséppp")]
    [InlineData("Mike Ross Josép Mike Ross Josép Mike Ross Josép Mike Ross Joséppp Joséppp Joséppp")]
    public void InvalidFirstNameGreaterThan64(string firstName)
    {
        var adminUser = new AdminUser { FirstName = firstName };
        var result = RunValidator(adminUser, "FirstName");

        result.ShouldHaveValidationErrorFor(admin => admin.FirstName).WithErrorMessage("Temp Message");
    }

    [Theory]
    [InlineData(" Mike Ross")]
    [InlineData("Mike Ross ")]
    [InlineData("Mike  Ross")]
    [InlineData("Mike50 Ross")]
    public void InvalidFirstNameByMatch(string firstName)
    {
        var adminUser = new AdminUser { FirstName = firstName };
        var result = RunValidator(adminUser, "FirstName");

        result.ShouldHaveValidationErrorFor(admin => admin.FirstName).WithErrorMessage("Temp Message");
    }

    [Theory]
    [InlineData("A")]
    [InlineData("Á")]
    [InlineData("Mike")]
    [InlineData("Mike Ross")]
    [InlineData("Mike Ross Josép Mike Ross Josép Mike Ross Josép Mike Ross Josépp")]
    public void ValidFirstName(string firstName)
    {
        var adminUser = new AdminUser { FirstName = firstName };
        var result = RunValidator(adminUser, "FirstName");

        result.ShouldNotHaveValidationErrorFor(admin => admin.FirstName);
    }

    [Fact]
    public void InvalidLastNameEmpty()
    {
        var adminUser = new AdminUser { LastName = "" };
        var result = RunValidator(adminUser, "LastName");

        result.ShouldHaveValidationErrorFor(admin => admin.LastName).WithErrorMessage("Temp Message");
    }

    [Theory]
    [InlineData("Mike Ross Josép Mike Ross Josép Mike Ross Josép Mike Ross Joséppp")]
    [InlineData("Mike Ross Josép Mike Ross Josép Mike Ross Josép Mike Ross Joséppp Joséppp Joséppp")]
    public void InvalidLastNameGreaterThan64(string lastName)
    {
        var adminUser = new AdminUser { LastName = lastName };
        var result = RunValidator(adminUser, "LastName");

        result.ShouldHaveValidationErrorFor(admin => admin.LastName).WithErrorMessage("Temp Message");
    }

    [Theory]
    [InlineData(" Mike Ross")]
    [InlineData("Mike Ross ")]
    [InlineData("Mike  Ross")]
    [InlineData("Mike50 Ross")]
    public void InvalidLastNameByMatch(string lastName)
    {
        var adminUser = new AdminUser { LastName = lastName };
        var result = RunValidator(adminUser, "LastName");

        result.ShouldHaveValidationErrorFor(admin => admin.LastName).WithErrorMessage("Temp Message");
    }

    [Theory]
    [InlineData("A")]
    [InlineData("Á")]
    [InlineData("Mike")]
    [InlineData("Mike Ross")]
    [InlineData("Mike Ross Josép Mike Ross Josép Mike Ross Josép Mike Ross Josépp")]
    public void ValidLastName(string lastName)
    {
        var adminUser = new AdminUser { LastName = lastName };
        var result = RunValidator(adminUser, "LastName");

        result.ShouldNotHaveValidationErrorFor(admin => admin.LastName);
    }


    [Fact]
    public void InvalidUsernameEmpty()
    {
        var adminUser = new AdminUser { Username = "" };
        var result = RunValidator(adminUser, "Username");

        result.ShouldHaveValidationErrorFor(admin => admin.Username).WithErrorMessage("Temp Message");
    }

    [Theory]
    [InlineData("Mike Ross Josép Mike Ross Joséppp")]
    [InlineData("Mike Ross Josép Mike Ross Joséppp Joséppp")]
    public void InvalidUsernameGreaterThan32(string username)
    {
        var adminUser = new AdminUser { Username = username };
        var result = RunValidator(adminUser, "Username");

        result.ShouldHaveValidationErrorFor(admin => admin.Username).WithErrorMessage("Temp Message");
    }

    [Theory]
    [InlineData(" mike.ross")]
    [InlineData("mike.ross ")]
    [InlineData("mike. ross")]
    [InlineData("mike.ross.")]
    [InlineData("Mike@Ross")]
    public void InvalidUsernameByMatch(string username)
    {
        var adminUser = new AdminUser { Username = username };
        var result = RunValidator(adminUser, "Username");

        result.ShouldHaveValidationErrorFor(admin => admin.Username).WithErrorMessage("Temp Message");
    }

    [Theory]
    [InlineData("mike.ross")]
    [InlineData("mike.ross.mike")]
    [InlineData("mike15oss")]
    [InlineData("Mike.Ross")]
    public void ValidUsername(string username)
    {
        var adminUser = new AdminUser { Username = username };
        var result = RunValidator(adminUser, "Username");

        result.ShouldNotHaveValidationErrorFor(admin => admin.Username);
    }

    [Theory]
    [InlineData("mikerossmikerossmikerossmikeross@mikerossmikerossmikerossmikeross")]
    [InlineData("mikerossmikerossmikerossmikeross@mikerossmikerossmikerossmikerossa")]
    public void InvalidEmailGreaterThan64(string email)
    {
        var adminUser = new AdminUser { Email = email };
        var result = RunValidator(adminUser, "Email");

        result.ShouldHaveValidationErrorFor(admin => admin.Email).WithErrorMessage("Temp Message");
    }

    [Theory]
    [InlineData("mikerosmikeros")]
    [InlineData("@mikerosmikerosa")]
    [InlineData("mikerosmikerosa@")]
    [InlineData("mikeros@mikerosa@")]
    public void InvalidEmailByMatch(string email)
    {
        var adminUser = new AdminUser { Email = email };
        var result = RunValidator(adminUser, "Email");

        result.ShouldHaveValidationErrorFor(admin => admin.Email).WithErrorMessage("Temp Message");
    }

    [Theory]
    [InlineData("mikeros@mikerosa")]
    [InlineData("miker.os@mikerosa")]
    [InlineData("mikerossmikerossmikerossmikeross@mikerossmikerossmikerossmikero")]
    public void ValidEmail(string email)
    {
        var adminUser = new AdminUser { Email = email };
        var result = RunValidator(adminUser, "Email");

        result.ShouldNotHaveValidationErrorFor(admin => admin.Email);
    }

    [Theory]
    [InlineData("m")]
    [InlineData("mikeros")]
    public void InvalidPasswordLessThanEight(string password)
    {
        var adminUser = new AdminUser { Password = password };
        var result = RunValidator(adminUser, "Password");

        result.ShouldHaveValidationErrorFor(admin => admin.Password).WithErrorMessage("Temp Message");
    }

    [Theory]
    [InlineData("Mike Ross Josép Mike Ross Joséppp")]
    [InlineData("Mike Ross Josép Mike Ross Joséppp Joséppp")]
    public void InvalidPasswordGreaterThan32(string password)
    {
        var adminUser = new AdminUser { Password = password };
        var result = RunValidator(adminUser, "Password");

        result.ShouldHaveValidationErrorFor(admin => admin.Password).WithErrorMessage("Temp Message");
    }

    [Theory]
    [InlineData("mikepass")]
    [InlineData("mikepassmikepass")]
    [InlineData("mike1pas@smika65epass86321#$amn%")]
    public void ValidPassword(string password)
    {
        var adminUser = new AdminUser { Password = password };
        var result = RunValidator(adminUser, "Password");

        result.ShouldNotHaveValidationErrorFor(admin => admin.Password);
    }

    [Theory]
    [InlineData("mikerossmikerossmikerossmikeross@mikerossmikerossmikerossmikeross")]
    [InlineData("mikerossmikerossmikerossmikeross@mikerossmikerossmikerossmikerossa")]
    public void InvalidProfileImageGreaterThan64(string profileImage)
    {
        var adminUser = new AdminUser { ProfileImage = profileImage };
        var result = RunValidator(adminUser, "ProfileImage");

        result.ShouldHaveValidationErrorFor(admin => admin.ProfileImage).WithErrorMessage("Temp Message");
    }

    [Theory]
    [InlineData(" ")]
    [InlineData("profile ")]
    [InlineData(" profile")]
    [InlineData("profile profile")]
    [InlineData("mikeross_aa@")]
    public void InvalidProfileImageByMatch(string profileImage)
    {
        var adminUser = new AdminUser { ProfileImage = profileImage };
        var result = RunValidator(adminUser, "ProfileImage");

        result.ShouldHaveValidationErrorFor(admin => admin.ProfileImage).WithErrorMessage("Temp Message");
    }

    [Theory]
    [InlineData(null)]
    [InlineData("mikeross_aa")]
    [InlineData("mikerossassdsd65658")]
    public void ValidProfileImage(string? profileImage)
    {
        var adminUser = new AdminUser { ProfileImage = profileImage };
        var result = RunValidator(adminUser, "ProfileImage");

        result.ShouldNotHaveValidationErrorFor(admin => admin.ProfileImage);
    }
}