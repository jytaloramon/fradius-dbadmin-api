using Crypt.Algorithms;
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

    public Task<AdminUser> Create(string fistName, string lastName, string username, string password,
        string email, string? profileImage)
    {
        throw new NotImplementedException();
        /*
        var adminUser = _factory.Create(fistName, lastName, username, password, email, profileImage, true);
        adminUser.Password = BCryptAlgorithm.GenHash(adminUser.Password);

        await _repository.Insert(adminUser);

        return adminUser;
        */
    }

    public Task<AdminUser?> GetById(int id)
    {
        throw new NotImplementedException();
    }

    public Task<List<AdminUser>> GetAll()
    {
        throw new NotImplementedException();
    }
}