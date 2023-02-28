using CommonDomain.Persistence;
using FradiusInfrastructure.Persistence;

namespace FradiusMigration;

public class DbConnection : DbContextPersistence
{
    public DbConnection() : base(SgbdConnectionFacade.Psql("", "", "", ""))
    {
    }
}