using FradiusDomain.Admin.Entities;
using FradiusDomain.Common.Repository;

namespace FradiusDomain.Admin.Repositories.Interfaces;

public interface IAdminUserRepository:IReadRepository<AdminUser>, IInsertRepository<AdminUser>
{
    
}