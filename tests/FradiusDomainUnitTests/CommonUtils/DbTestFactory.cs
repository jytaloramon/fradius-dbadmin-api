using FradiusDomain.Common.Persistence;
using Infrastructure.Persistence.DbConnection;
using Infrastructure.Persistence.Exceptions.Factories;

namespace FradiusDomainUnitTests.CommonUtils;

public static class DbTestFactory
{
    public static DbContextDataPersistence Create()
    {
        return new DbContextDataPersistence(
            new PsqlSgbd("", "", "", ""),
            new PsqlSgbdExceptionFactory());
    }
}