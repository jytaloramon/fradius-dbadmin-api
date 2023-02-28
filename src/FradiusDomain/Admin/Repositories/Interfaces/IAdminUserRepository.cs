using CommonDomain.Repository;
using FradiusDomain.Admin.Entities;

namespace FradiusDomain.Admin.Repositories.Interfaces;

public interface IAdminUserRepository : IReadRepository<AdminUser>, IInsertRepository<AdminUser>
{
}