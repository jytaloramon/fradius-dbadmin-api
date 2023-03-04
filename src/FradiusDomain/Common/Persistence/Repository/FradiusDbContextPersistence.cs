using FradiusDomain.Admin.Entities;
using Infrastructure.Persistence.Db;
using Microsoft.EntityFrameworkCore;

namespace FradiusDomain.Common.Persistence.Repository;

public class FradiusDbContextPersistence : DbContextPersistence
{
    public FradiusDbContextPersistence(Func<DbContextOptionsBuilder, Action?> configOptionsBuilder)
        : base(configOptionsBuilder)
    {
    }

    public FradiusDbContextPersistence(Func<DbContextOptionsBuilder, Action?> configOptionsBuilder,
        Func<ModelBuilder, Action?>? configModelBuilder) : base(configOptionsBuilder, configModelBuilder)
    {
    }

    public DbSet<AdminUser> AdminUsers { get; set; }
}