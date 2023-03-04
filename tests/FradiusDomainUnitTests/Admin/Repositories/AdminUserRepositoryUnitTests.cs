using FradiusDomain.Admin.Entities;
using FradiusDomain.Admin.Repositories;
using FradiusDomainUnitTests.CommonUtils;
using Infrastructure.Persistence.Exceptions.IntegrityConstraint;

namespace FradiusDomainUnitTests.Admin.Repositories;

public class AdminUserRepositoryUnitTests
{
    private readonly AdminUserRepository _repository;

    public AdminUserRepositoryUnitTests()
    {
        _repository = new AdminUserRepository(DbTestFactory.Create());
    }

    private static AdminUser CreateAdminUser(string text)
    {
        return new AdminUser
        {
            FirstName = text + "_f",
            LastName = text + "_l",
            Username = text + "_u",
            Email = text + "_@e",
            Password = text + "_p",
            ProfileImage = text + "_path",
            IsActive = true,
        };
    }

    private static AdminUser CreateAdminUser(int id, string text)
    {
        return new AdminUser
        {
            Id = id,
            FirstName = text + "#" + id + "_f",
            LastName = text + "#" + id + "_l",
            Username = text + "#" + id + "_u",
            Email = text + "#" + id + "_@e",
            Password = text + "#" + id + "_p",
            ProfileImage = text + "#" + id + "_path",
            IsActive = true,
        };
    }

    [Theory]
    [InlineData("Mary")]
    [InlineData("Mike")]
    [InlineData("John")]
    public void Insert_NewEntity_ReturnOneValue(string text)
    {
        var newText = text + GenerateTestId.GenLong(GenerateTestId.LongMax);

        var newUser = CreateAdminUser(newText);

        var actual = _repository.Insert(newUser);

        Assert.Equal(1, actual);
    }

    [Theory]
    [InlineData("Mary")]
    [InlineData("Mike")]
    [InlineData("John")]
    public void Insert_DuplicateUsername_ThrowUniqueConstraintViolation(string text)
    {
        var newText = text + GenerateTestId.GenLong(GenerateTestId.LongMax);

        var newUser = CreateAdminUser(newText);
        _repository.Insert(newUser);

        var newUserUsernameDuplicate = CreateAdminUser(newText);
        newUserUsernameDuplicate.Email = text + GenerateTestId.GenLong(GenerateTestId.LongMax);

        var actualException = Assert.Throws<UniqueConstraintViolation>(() =>
        {
            _repository.Insert(newUserUsernameDuplicate);
        });

        Assert.Equal("Username", actualException.Property);
    }

    [Theory]
    [InlineData("Mary")]
    [InlineData("Mike")]
    [InlineData("John")]
    public void Insert_DuplicateEmail_ThrowUniqueConstraintViolation(string text)
    {
        var newText = text + GenerateTestId.GenLong(GenerateTestId.LongMax);

        var newUser = CreateAdminUser(newText);
        _repository.Insert(newUser);

        var newUserUsernameDuplicate = CreateAdminUser(newText);
        newUserUsernameDuplicate.Username = text + GenerateTestId.GenLong(GenerateTestId.LongMax);

        var actualException = Assert.Throws<UniqueConstraintViolation>(() =>
        {
            _repository.Insert(newUserUsernameDuplicate);
        });

        Assert.Equal("Email", actualException.Property);
    }

    [Theory]
    [InlineData("Mary")]
    [InlineData("Mike")]
    [InlineData("John")]
    public void GetById_ExistentId_ReturnAnEntity(string text)
    {
        var id = GenerateTestId.GenInt(GenerateTestId.IntMax);
        var newText = text + GenerateTestId.GenLong(GenerateTestId.IntMax);

        var newUser = CreateAdminUser(id, newText);
        _repository.Insert(newUser);

        var actualUser = _repository.GetById(id);

        Assert.NotNull(actualUser);
    }

    [Fact]
    public void GetById_NonExistentId_ReturnNull()
    {
        var adminUser = _repository.GetById(GenerateTestId.IntMax + 1);

        Assert.Null(adminUser);
    }
}