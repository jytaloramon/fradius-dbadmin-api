using CommonInfrastructure.Persistence.Db;
using CommonInfrastructure.Persistence.DbConnection;

namespace FradiusMigration;

public class DbConnection : DbContextPersistence
{
    public DbConnection() : base((new PsqlSgbd("", "", "", "", ""))
        .GetOptionsBuilderConstructor())
    {
    }
}