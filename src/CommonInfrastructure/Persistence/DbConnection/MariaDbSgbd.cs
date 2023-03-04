using Infrastructure.Persistence.Db;
using Infrastructure.Persistence.Db.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.DbConnection;

public class MariaDbSgbd : Sgbd, ISgbd
{
    private readonly MariaDbServerVersion _serverVersion;

    public MariaDbSgbd(string host, string user, string password, string dbName, ServerVersion version) : base(host,
        "3306", user, password, dbName)
    {
        _serverVersion = new MariaDbServerVersion(version);
    }

    public MariaDbSgbd(string host, string port, string user, string password, string dbName, ServerVersion version) :
        base(host, port, user, password, dbName)
    {
        _serverVersion = new MariaDbServerVersion(version);
    }

    public Func<DbContextOptionsBuilder, Action?> GetOptionsBuilderConstructor()
    {
        return builder =>
        {
            builder.UseMySql($"server={Host};port={Port};user={User};password={Password};database={DbName}",
                _serverVersion);
            return null;
        };
    }
}