using FradiusInfrastructure.Persistence;

namespace FradiusMigration;

public class DbConnection : FradiusDbConnection
{
    public DbConnection() : base(SgbdConnectionFacade.MariaDb(
        "any", "any", "any", "any", new Version(10, 9, 5)))
    {
    }
}