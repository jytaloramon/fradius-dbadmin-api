using CommonDomain.Persistence.Interfaces;
using FradiusDomain.Admin.Entities;
using FradiusDomain.Admin.Repositories.Interfaces;
using FradiusDomain.Common.Persistence.Repository;
using Microsoft.EntityFrameworkCore;

namespace FradiusDomain.Admin.Repositories;

public class AdminUserRepository : IAdminUserRepository
{
    private readonly IDataPersistence<FradiusDbContextPersistence> _persistence;

    public AdminUserRepository(IDataPersistence<FradiusDbContextPersistence> persistence)
    {
        _persistence = persistence;
    }

    public async Task<AdminUser?> GetById(int id)
    {
        await using var db = _persistence.GetRepositoryData();

        return await db.AdminUsers.FindAsync(id);
    }

    public async Task<List<AdminUser>> GetAll()
    {
        await using var db = _persistence.GetRepositoryData();

        return await db.AdminUsers.ToListAsync();
    }

    public async Task Insert(AdminUser adminUser)
    {
        await using var db = _persistence.GetRepositoryData();

        db.AdminUsers.Add(adminUser);
        await db.SaveChangesAsync();
    }
}