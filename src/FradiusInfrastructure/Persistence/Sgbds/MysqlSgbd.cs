using FradiusInfrastructure.Persistence.Sgbds.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FradiusInfrastructure.Persistence.Sgbds;

public class MysqlSgbd : Sgbd, ISgbd
{
    private readonly MySqlServerVersion _serverVersion;

    public MysqlSgbd(string host, string user, string password, string dbName, ServerVersion version)
        : base(host, "3306", user, password, dbName)
    {
        _serverVersion = new MySqlServerVersion(version);
    }

    public MysqlSgbd(string host, string port, string user, string password, string dbName, ServerVersion version)
        : base(host, port, user, password, dbName)
    {
        _serverVersion = new MySqlServerVersion(version);
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