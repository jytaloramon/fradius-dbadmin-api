using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Db;

public abstract class DbContextPersistence : DbContext
{
    private readonly Func<DbContextOptionsBuilder, Action?> _configOptionsBuilder;
    private readonly Func<ModelBuilder, Action?>? _configModelBuilder;

    protected DbContextPersistence(Func<DbContextOptionsBuilder, Action?> configOptionsBuilder)
    {
        _configOptionsBuilder = configOptionsBuilder;
    }

    protected DbContextPersistence(Func<DbContextOptionsBuilder, Action?> configOptionsBuilder,
        Func<ModelBuilder, Action?>? configModelBuilder)
    {
        _configOptionsBuilder = configOptionsBuilder;
        _configModelBuilder = configModelBuilder;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        _configOptionsBuilder(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        if (_configModelBuilder != null)
        {
            _configModelBuilder(modelBuilder);
            return;
        }

        base.OnModelCreating(modelBuilder);
    }
}