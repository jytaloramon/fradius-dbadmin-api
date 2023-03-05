using CommonInfrastructure.Persistence.Exceptions.Entities;
using CommonInfrastructure.Persistence.Exceptions.IntegrityConstraint;
using CommonInfrastructure.Persistence.Handler.Interfaces;
using Npgsql;

namespace CommonInfrastructure.Persistence.Handler;

public class PsqlHandlerPersistenceException : IHandlerPersistenceException
{
    public SgbdException Handler(Exception exception)
    {
        if (exception is not PostgresException && exception.InnerException is not PostgresException)
        {
            return new SgbdException("Database", "An unexpected error occurred", exception);
        }

        var psqlException =
            (exception is PostgresException ? exception : exception.InnerException) as PostgresException;

        var property = GetPropertyName(psqlException!.ConstraintName!);

        return psqlException.SqlState switch
        {
            "23505" => new UniqueConstraintViolation(property, "Duplicate Key"),
            _ => new SgbdException("Database", "An unexpected error occurred", exception)
        };
    }

    private static string GetPropertyName(string nameRaw)
    {
        var tokensName = nameRaw.Split("_");

        return string.Join("", ToUpperOnlyFirstChar(tokensName[2..]));
    }

    private static string[] ToUpperOnlyFirstChar(IReadOnlyList<string> words)
    {
        var wordsUpper = new string[words.Count];

        for (var i = 0; i < words.Count; i++)
        {
            wordsUpper[i] = char.ToUpper(words[i][0]).ToString() + words[i][1..];
        }

        return wordsUpper;
    }
}