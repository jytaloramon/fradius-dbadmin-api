using CommonDomain.CryptAlgorithms;
using CommonDomain.Handlers;
using CommonInfrastructure.Persistence.Exceptions;
using FradiusDomain.Admin.Entities;
using FradiusDomain.Admin.EntitiesFactories.Interfaces;
using FradiusDomain.Admin.Repositories.Interfaces;
using FradiusDomain.Admin.UseCases.Interfaces;

namespace FradiusDomain.Admin.UseCases;

public class AdminUseCases : IAdminUseCases
{
    private readonly IAdminUserFactory _factory;

    private readonly IAdminUserRepository _repository;

    public AdminUseCases(IAdminUserFactory factory, IAdminUserRepository repository)
    {
        _factory = factory;
        _repository = repository;
    }

    public Task<AdminUser?> GetById(int id)
    {
        var adminUser = _factory.Create(id);

        try
        {
            return Task.FromResult(_repository.GetById(adminUser.Id));
        }
        catch (SgbdException e)
        {
            throw UseCasesHandlerSgbdException.Handler(e);
        }
    }

    public Task<List<AdminUser>> GetAll()
    {
        try
        {
            return Task.FromResult(_repository.GetAll());
        }
        catch (SgbdException e)
        {
            throw UseCasesHandlerSgbdException.Handler(e);
        }
    }

    public Task<AdminUser> Create(string firstName, string lastName, string username, string password, string email,
        string? profileImage)
    {
        var adminUser = _factory.Create(firstName, lastName, username, password, email, profileImage, true);
        adminUser.Password = BCryptAlgorithm.GenHash(adminUser.Password);

        try
        {
            _repository.Insert(adminUser);
        }
        catch (SgbdException e)
        {
            throw UseCasesHandlerSgbdException.Handler(e);
        }

        return Task.FromResult(adminUser);
    }
}