using CommonInfrastructure.Persistence.Db.Interfaces;
using FradiusDomain.Admin.Entities;
using FradiusDomain.Admin.Repositories.Interfaces;
using FradiusDomain.Common.Persistence.Repository;

namespace FradiusDomain.Admin.Repositories;

public class AdminUserRepository : IAdminUserRepository
{
    private readonly IDataPersistence<FradiusDbContextPersistence> _persistence;

    public AdminUserRepository(IDataPersistence<FradiusDbContextPersistence> persistence)
    {
        _persistence = persistence;
    }

    public AdminUser? GetById(int id)
    {
        try
        {
            using var db = _persistence.GetRepositoryData();

            return db.AdminUsers.Find(id);
        }
        catch (Exception e)
        {
            throw _persistence.HandlerException(e);
        }
    }

    public List<AdminUser> GetAll()
    {
        try
        {
            using var db = _persistence.GetRepositoryData();

            return db.AdminUsers.ToList();
        }
        catch (Exception e)
        {
            throw _persistence.HandlerException(e);
        }
    }

    public int Insert(AdminUser adminUser)
    {
        try
        {
            using var db = _persistence.GetRepositoryData();

            db.AdminUsers.Add(adminUser);
            return db.SaveChanges();
        }
        catch (Exception e)
        {
            throw _persistence.HandlerException(e);
        }
    }
}