using FluentValidation.TestHelper;
using RadiusDomain.User.Entities;
using RadiusDomain.User.Entities.Validations;

namespace RadiusDomainUnitTests.User.Entities.Validations;

public class UserAttributeValidatorUnitTests
{
    private readonly UserAttributeValidator _validator;

    public UserAttributeValidatorUnitTests()
    {
        _validator = new UserAttributeValidator();
    }

    private TestValidationResult<UserAttribute> RunValidator(UserAttribute userAttribute, string property)
    {
        return _validator.TestValidate(userAttribute, strategy => strategy.IncludeRuleSets(property));
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-100)]
    [InlineData(-1000)]
    public void Id_LessThanOrEqualZero_ShouldHaveValidationError(int id)
    {
        var validationResult = RunValidator(new UserAttribute { Id = id }, "Id");

        validationResult.ShouldHaveValidationErrorFor(userAttribute => userAttribute.Id)
            .WithErrorMessage("Temp Message");
    }

    [Theory]
    [InlineData(1)]
    [InlineData(100)]
    [InlineData(1000)]
    public void Id_GreaterThanZero_ShouldNotHaveValidationError(int id)
    {
        var validationResult = RunValidator(new UserAttribute { Id = id }, "Id");

        validationResult.ShouldNotHaveValidationErrorFor(userAttribute => userAttribute.Id);
    }

    [Fact]
    public void Username_Empty_ShouldHaveValidationError()
    {
        var validationResult = RunValidator(new UserAttribute { Username = "" }, "Username");

        validationResult.ShouldHaveValidationErrorFor(userAttribute => userAttribute.Username)
            .WithErrorMessage("Temp Message");
    }

    [Theory]
    [InlineData("message_message_message_message_message_message_message_message_f")]
    [InlineData("message_message_message_message_message_message_message_message_message_")]
    public void Username_GreaterThan64_ShouldHaveValidationError(string username)
    {
        var validationResult = RunValidator(new UserAttribute { Username = username }, "Username");

        validationResult.ShouldHaveValidationErrorFor(userAttribute => userAttribute.Username)
            .WithErrorMessage("Temp Message");
    }

    [Theory]
    [InlineData(" message_")]
    [InlineData("message_ ")]
    [InlineData("message.")]
    [InlineData(".message")]
    [InlineData("mes@_sage")]
    public void Username_OutMatchesUsername_ShouldHaveValidationError(string username)
    {
        var validationResult = RunValidator(new UserAttribute { Username = username }, "Username");

        validationResult.ShouldHaveValidationErrorFor(userAttribute => userAttribute.Username)
            .WithErrorMessage("Temp Message");
    }

    [Theory]
    [InlineData("message")]
    [InlineData("4message")]
    [InlineData("mes.656sage")]
    public void Username_Valid_ShouldNotHaveValidationError(string username)
    {
        var validationResult = RunValidator(new UserAttribute { Username = username }, "Username");

        validationResult.ShouldNotHaveValidationErrorFor(userAttribute => userAttribute.Username);
    }

    [Fact]
    public void Attribute_Empty_ShouldHaveValidationError()
    {
        var validationResult = RunValidator(new UserAttribute { Attribute = "" }, "Attribute");

        validationResult.ShouldHaveValidationErrorFor(userAttribute => userAttribute.Attribute)
            .WithErrorMessage("Temp Message");
    }

    [Theory]
    [InlineData("message_message_message_message_message_message_message_message_f")]
    [InlineData("message_message_message_message_message_message_message_message_message_")]
    public void Attribute_GreaterThan64_ShouldHaveValidationError(string attribute)
    {
        var validationResult = RunValidator(new UserAttribute { Attribute = attribute }, "Attribute");

        validationResult.ShouldHaveValidationErrorFor(userAttribute => userAttribute.Attribute)
            .WithErrorMessage("Temp Message");
    }

    [Theory]
    [InlineData(" message_")]
    [InlineData("message_ ")]
    [InlineData("mes sage")]
    public void Attribute_OutMatchesAttribute_ShouldHaveValidationError(string attribute)
    {
        var validationResult = RunValidator(new UserAttribute { Attribute = attribute }, "Attribute");

        validationResult.ShouldHaveValidationErrorFor(userAttribute => userAttribute.Attribute)
            .WithErrorMessage("Temp Message");
    }

    [Theory]
    [InlineData("message")]
    [InlineData("4mess-a_ge")]
    [InlineData("mes.656sage")]
    public void Attribute_Valid_ShouldNotHaveValidationError(string attribute)
    {
        var validationResult = RunValidator(new UserAttribute { Attribute = attribute }, "Attribute");

        validationResult.ShouldNotHaveValidationErrorFor(userAttribute => userAttribute.Attribute);
    }

    [Fact]
    public void Operation_Empty_ShouldHaveValidationError()
    {
        var validationResult = RunValidator(new UserAttribute { Operation = "" }, "Operation");

        validationResult.ShouldHaveValidationErrorFor(userAttribute => userAttribute.Operation)
            .WithErrorMessage("Temp Message");
    }

    [Theory]
    [InlineData("message_message_message_message_message_message_message_message_f")]
    [InlineData("message_message_message_message_message_message_message_message_message_")]
    public void Operation_GreaterThan64_ShouldHaveValidationError(string operation)
    {
        var validationResult = RunValidator(new UserAttribute { Operation = operation }, "Operation");

        validationResult.ShouldHaveValidationErrorFor(userAttribute => userAttribute.Operation)
            .WithErrorMessage("Temp Message");
    }

    [Theory]
    [InlineData(" message_")]
    [InlineData("message_ ")]
    [InlineData("mes sage")]
    public void Operation_OutMatchesOperation_ShouldHaveValidationError(string operation)
    {
        var validationResult = RunValidator(new UserAttribute { Operation = operation }, "Operation");

        validationResult.ShouldHaveValidationErrorFor(userAttribute => userAttribute.Operation)
            .WithErrorMessage("Temp Message");
    }

    [Theory]
    [InlineData("message")]
    [InlineData("4mess-a_ge")]
    [InlineData("mes.656sage")]
    public void Operation_Valid_ShouldNotHaveValidationError(string operation)
    {
        var validationResult = RunValidator(new UserAttribute { Operation = operation }, "Operation");

        validationResult.ShouldNotHaveValidationErrorFor(userAttribute => userAttribute.Operation);
    }

    [Fact]
    public void Value_Empty_ShouldHaveValidationError()
    {
        var validationResult = RunValidator(new UserAttribute { Value = "" }, "Value");

        validationResult.ShouldHaveValidationErrorFor(userAttribute => userAttribute.Value)
            .WithErrorMessage("Temp Message");
    }

    [Theory]
    [InlineData("message_message_message_message_message_message_message_message_f")]
    [InlineData("message_message_message_message_message_message_message_message_message_")]
    public void Value_GreaterThan64_ShouldHaveValidationError(string value)
    {
        var validationResult = RunValidator(new UserAttribute { Value = value }, "Value");

        validationResult.ShouldHaveValidationErrorFor(userAttribute => userAttribute.Value)
            .WithErrorMessage("Temp Message");
    }

    [Theory]
    [InlineData(" message_")]
    [InlineData("message_ ")]
    [InlineData("mes sage")]
    public void Value_OutMatchesValue_ShouldHaveValidationError(string value)
    {
        var validationResult = RunValidator(new UserAttribute { Value = value }, "Value");

        validationResult.ShouldHaveValidationErrorFor(userAttribute => userAttribute.Value)
            .WithErrorMessage("Temp Message");
    }

    [Theory]
    [InlineData("message")]
    [InlineData("4mess-a_ge")]
    [InlineData("mes.656sage")]
    public void Value_Valid_ShouldNotHaveValidationError(string value)
    {
        var validationResult = RunValidator(new UserAttribute { Value = value }, "Value");

        validationResult.ShouldNotHaveValidationErrorFor(userAttribute => userAttribute.Value);
    }
}