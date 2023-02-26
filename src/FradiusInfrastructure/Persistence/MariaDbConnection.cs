using Microsoft.EntityFrameworkCore;

namespace FradiusInfrastructure.Persistence;

public class MariaDbConnection : DbConnection
{
    private readonly MariaDbServerVersion _serverVersion;

    public MariaDbConnection(string host, string user, string password, string dbName, Version version) : base(host,
        user, password, dbName)
    {
        _serverVersion = new MariaDbServerVersion(version);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySql($"server={Host};user={User};password={Password};database={DbName}",
            _serverVersion);
    }
}