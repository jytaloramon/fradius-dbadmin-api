using Infrastructure.Persistence.Db;
using Infrastructure.Persistence.Db.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.DbConnection;

public class PsqlSgbd : Sgbd, ISgbd
{
    public PsqlSgbd(string host, string user, string password, string dbName)
        : base(host, "5432", user, password, dbName)
    {
    }

    public PsqlSgbd(string host, string port, string user, string password, string dbName)
        : base(host, port, user, password, dbName)
    {
    }

    public Func<DbContextOptionsBuilder, Action?> GetOptionsBuilderConstructor()
    {
        return builder =>
        {
            builder.UseNpgsql($"Host={Host};Port={Port};Username={User};Password={Password};Database={DbName}");
            return null;
        };
    }
}