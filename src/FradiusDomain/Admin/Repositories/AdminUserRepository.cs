using CommonDomain.Persistence;
using FradiusDomain.Admin.Entities;
using FradiusDomain.Admin.Repositories.Interfaces;
using FradiusDomain.Common.Persistence;

namespace FradiusDomain.Admin.Repositories;

public class AdminUserRepository : IAdminUserRepository
{
    private readonly DataPersistence<FradiusDbContextPersistence> _persistence;

    public AdminUserRepository(DataPersistence<FradiusDbContextPersistence> persistence)
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