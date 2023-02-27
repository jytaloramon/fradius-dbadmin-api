using FradiusInfrastructure.Persistence;

namespace FradiusMigration;

public class DbConnection : FradiusDbConnection
{
    public DbConnection() : base(SgbdConnectionFacade.Psql("", "", "", ""))
    {
    }
}