namespace FradiusInfrastructure.Persistence.Sgbds;

public abstract class Sgbd
{
    protected Sgbd(string host, string port, string user, string password, string dbName)
    {
        Host = host;
        Port = port;
        User = user;
        Password = password;
        DbName = dbName;
    }

    protected string Host { get; init; }

    protected string Port { get; init; }

    protected string User { get; init; }

    protected string Password { get; init; }

    protected string DbName { get; init; }
}