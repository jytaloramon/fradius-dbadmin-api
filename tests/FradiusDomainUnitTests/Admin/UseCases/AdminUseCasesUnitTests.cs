using Common.Exceptions;
using CommonInfrastructure.Persistence.Exceptions;
using FradiusDomain.Admin.Entities;
using FradiusDomain.Admin.EntitiesFactories.Interfaces;
using FradiusDomain.Admin.Repositories.Interfaces;
using FradiusDomain.Admin.UseCases;
using Moq;

namespace FradiusDomainUnitTests.Admin.UseCases;

public class AdminUseCasesUnitTests
{
    [Fact]
    public async Task GetById_ValidIdAndFound_ReturnAdminUser()
    {
        const int id = 1;

        var factory = new Mock<IAdminUserFactory>();
        factory.Setup(userFactory => userFactory.Create(id)).Returns(new AdminUser { Id = id });

        var repository = new Mock<IAdminUserRepository>();
        repository.Setup(userRepository => userRepository.GetById(id)).Returns(new AdminUser { Id = id });

        var useCases = new AdminUseCases(factory.Object, repository.Object);

        var userActual = await useCases.GetById(id);

        Assert.NotNull(userActual);
    }

    [Fact]
    public async Task GetById_ValidIdAndNotFound_ReturnNull()
    {
        const int id = 1;

        var factory = new Mock<IAdminUserFactory>();
        factory.Setup(userFactory => userFactory.Create(id)).Returns(new AdminUser { Id = id });

        var repository = new Mock<IAdminUserRepository>();
        repository.Setup(userRepository => userRepository.GetById(id)).Returns((AdminUser?)null);

        var useCases = new AdminUseCases(factory.Object, repository.Object);

        var userActual = await useCases.GetById(id);

        Assert.Null(userActual);
    }

    [Fact]
    public async Task GetById_FactoryThrowException_ThrowBaseException()
    {
        const int id = 1;

        var factory = new Mock<IAdminUserFactory>();
        factory.Setup(userFactory => userFactory.Create(id))
            .Throws(new EntityValidationException(new Dictionary<string, string[]>()
            {
                ["Id"] = new[] { "Id - error" }
            }));

        var repository = new Mock<IAdminUserRepository>();

        var useCases = new AdminUseCases(factory.Object, repository.Object);

        var exceptionActual = await Assert.ThrowsAnyAsync<BaseException>(async () => { await useCases.GetById(id); });

        Assert.Single(exceptionActual.Errors);
        Assert.True(exceptionActual.Errors.ContainsKey("Id"));
    }

    [Fact]
    public async Task GetById_RepositoryThrowException_ThrowBaseException()
    {
        const int id = 1;

        var factory = new Mock<IAdminUserFactory>();
        factory.Setup(userFactory => userFactory.Create(id)).Returns(new AdminUser { Id = id });

        var repository = new Mock<IAdminUserRepository>();
        repository.Setup(userRepository => userRepository.GetById(id))
            .Throws(new SgbdException("Database", "server - down"));

        var useCases = new AdminUseCases(factory.Object, repository.Object);

        var exceptionActual = await Assert.ThrowsAnyAsync<BaseException>(async () => { await useCases.GetById(id); });

        Assert.Single(exceptionActual.Errors);
        Assert.True(exceptionActual.Errors.ContainsKey("Database"));
    }

    [Fact]
    public async Task GetAll_ReturnAdminUserList()
    {
        const int id = 1;

        var factory = new Mock<IAdminUserFactory>();
        factory.Setup(userFactory => userFactory.Create(id)).Returns(new AdminUser { Id = id });

        var repository = new Mock<IAdminUserRepository>();
        repository.Setup(userRepository => userRepository.GetAll())
            .Returns(new List<AdminUser>() { new AdminUser { Id = id } });

        var useCases = new AdminUseCases(factory.Object, repository.Object);

        var adminUsersActual = await useCases.GetAll();

        Assert.Single(adminUsersActual);
        Assert.Equal(id, adminUsersActual[0].Id);
    }

    [Fact]
    public async Task GetAll_RepositoryThrowException_ThrowBaseException()
    {
        const int id = 1;

        var factory = new Mock<IAdminUserFactory>();
        factory.Setup(userFactory => userFactory.Create(id)).Returns(new AdminUser { Id = id });

        var repository = new Mock<IAdminUserRepository>();
        repository.Setup(userRepository => userRepository.GetAll())
            .Throws(new SgbdException("Database", "server - down"));

        var useCases = new AdminUseCases(factory.Object, repository.Object);

        var exceptionActual = await Assert.ThrowsAnyAsync<BaseException>(async () => { await useCases.GetAll(); });

        Assert.Single(exceptionActual.Errors);
        Assert.True(exceptionActual.Errors.ContainsKey("Database"));
    }

    [Fact]
    public async Task Create_ValidData_ReturnAdminUser()
    {
        const int id = 1;

        var factory = new Mock<IAdminUserFactory>();
        factory.Setup(userFactory => userFactory
                .Create("", "", "", "", "", "", true))
            .Returns(new AdminUser { Id = id });

        var repository = new Mock<IAdminUserRepository>();
        repository.Setup(userRepository => userRepository.Insert(new AdminUser { Id = id })).Returns(1);

        var useCases = new AdminUseCases(factory.Object, repository.Object);

        var adminUserActual = await useCases.Create("", "", "", "", "", "");

        Assert.Equal(id, adminUserActual.Id);
        Assert.Matches(@"^\$.+\$.+$", adminUserActual.Password);
    }

    [Fact]
    public async Task Create_FactoryThrowException_ThrowBaseException()
    {
        var factory = new Mock<IAdminUserFactory>();
        factory.Setup(userFactory => userFactory
                .Create("", "", "", "", "", "", true))
            .Throws(new EntityValidationException(new Dictionary<string, string[]>()
            {
                ["Name"] = new[] { "Name - error" }
            }));

        var repository = new Mock<IAdminUserRepository>();

        var useCases = new AdminUseCases(factory.Object, repository.Object);

        var exceptionActual = await Assert.ThrowsAnyAsync<BaseException>(
            async () => { await useCases.Create("", "", "", "", "", ""); });

        Assert.Single(exceptionActual.Errors);
        Assert.True(exceptionActual.Errors.ContainsKey("Name"));
    }

    [Fact]
    public async Task Create_RepositoryThrowException_ThrowBaseException()
    {
        var factory = new Mock<IAdminUserFactory>();
        factory.Setup(userFactory => userFactory
                .Create("", "", "", "", "", "", true))
            .Returns(new AdminUser());

        var repository = new Mock<IAdminUserRepository>();
        repository.Setup(userRepository => userRepository.Insert(new AdminUser()))
            .Throws(new SgbdException("Database", "server - down"));

        var useCases = new AdminUseCases(factory.Object, repository.Object);

        var exceptionActual = await Assert.ThrowsAnyAsync<BaseException>(
            async () => { await useCases.Create("", "", "", "", "", ""); });

        Assert.Single(exceptionActual.Errors);
        Assert.True(exceptionActual.Errors.ContainsKey("Database"));
    }
}