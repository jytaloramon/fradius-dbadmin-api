using FradiusDomain.Admin.Entities;
using FradiusInfrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace FradiusDomain.Common.Repository;

public class DataRepository : FradiusDbConnection
{
    public DataRepository(Func<DbContextOptionsBuilder, Action?> configOptionsBuilder)
        : base(configOptionsBuilder, PropertyMapperRepository.Mapper())
    {
    }

    public DbSet<AdminUser> AdminUsers { get; set; }
}