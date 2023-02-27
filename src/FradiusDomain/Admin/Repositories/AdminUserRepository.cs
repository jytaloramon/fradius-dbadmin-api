using FradiusDomain.Admin.Entities;
using FradiusDomain.Admin.Repositories.Interfaces;
using FradiusDomain.Common.Repository;

namespace FradiusDomain.Admin.Repositories;

public class AdminUserRepository : IAdminUserRepository
{
    private readonly IDataRepositoryPool _repositoryPool;
    
    public AdminUserRepository(IDataRepositoryPool repositoryPool)
    {
        _repositoryPool = repositoryPool;
    }
    
    public Task<AdminUser?> GetById(int id)
    {
        throw new NotImplementedException();
    }

    public Task<List<AdminUser>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task Insert(AdminUser t)
    {
        throw new NotImplementedException();
    }
}