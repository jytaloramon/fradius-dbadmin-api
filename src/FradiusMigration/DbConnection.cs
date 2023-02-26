using FradiusInfrastructure.Persistence;

namespace FradiusMigration;

public class DbConnection : MariaDbConnection
{
    public DbConnection() : base("", "", "", "", new Version(0, 0, 0))
    {
    }
}