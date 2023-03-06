using FradiusDomain.Common.Persistence;
using CommonInfrastructure.Persistence.DbConnection;
using CommonInfrastructure.Persistence.Handler;

namespace FradiusDomainUnitTests.CommonUtils;

public static class DbTestFactory
{
    public static DbContextDataPersistence Create()
    {
        return new DbContextDataPersistence(
            new PsqlSgbd("", "", "", ""),
            new PsqlHandlerPersistenceException());
    }
}