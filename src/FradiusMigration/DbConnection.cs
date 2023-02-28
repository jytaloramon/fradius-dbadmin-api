using CommonDomain.Persistence;
using FradiusInfrastructure.Persistence.Sgbds;

namespace FradiusMigration;

public class DbConnection : DbContextPersistence
{
    public DbConnection() : base((new PsqlSgbd("", "", "", "", ""))
        .GetOptionsBuilderConstructor())
    {
    }
}