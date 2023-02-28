using CommonDomain.Persistence;
using CommonDomain.Persistence.Interfaces;
using FradiusDomain.Admin.Entities;
using FradiusDomain.Admin.Repositories.Interfaces;
using FradiusDomain.Common.Persistence;
using FradiusDomain.Common.Persistence.Repository;

namespace FradiusDomain.Admin.Repositories;

public class AdminUserRepository : IAdminUserRepository
{
    private readonly IDataPersistence<FradiusDbContextPersistence> _persistence;

    public AdminUserRepository(IDataPersistence<FradiusDbContextPersistence> persistence)
    {
        _persistence = persistence;
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