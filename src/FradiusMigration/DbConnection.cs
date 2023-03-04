using Infrastructure.Persistence.Db;
using Infrastructure.Persistence.DbConnection;

namespace FradiusMigration;

public class DbConnection : DbContextPersistence
{
    public DbConnection() : base((new PsqlSgbd("", "", "", "", ""))
        .GetOptionsBuilderConstructor())
    {
    }
}