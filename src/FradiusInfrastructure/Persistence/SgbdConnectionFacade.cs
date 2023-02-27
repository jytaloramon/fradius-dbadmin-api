using Microsoft.EntityFrameworkCore;

namespace FradiusInfrastructure.Persistence;

public static class SgbdConnectionFacade
{
    public static Func<DbContextOptionsBuilder, Action?> MariaDb(string host, string user, string password,
        string dbName,
        Version version)
    {
        return builder =>
        {
            builder.UseMySql($"server={host};user={user};password={password};database={dbName}",
                new MariaDbServerVersion(version));
            return null;
        };
    }

    public static Func<DbContextOptionsBuilder, Action?> MySql(string host, string user, string password, string dbName,
        Version version)
    {
        return builder =>
        {
            builder.UseMySql($"server={host};user={user};password={password};database={dbName}",
                new MySqlServerVersion(version));
            return null;
        };
    }
}