using Common.Exceptions;
using Infrastructure.Persistence.Exceptions.Factories.Interfaces;
using Npgsql;

namespace Infrastructure.Persistence.Exceptions.Factories;

public class PsqlSgbdExceptionFactory : ISgbdExceptionFactory
{
    public BaseException Create(Exception exception)
    {
        throw new NotImplementedException();
    }
}