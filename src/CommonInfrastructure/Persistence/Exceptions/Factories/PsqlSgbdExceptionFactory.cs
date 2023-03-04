using Infrastructure.Persistence.Exceptions.Entities;
using Infrastructure.Persistence.Exceptions.Factories.Interfaces;

namespace Infrastructure.Persistence.Exceptions.Factories;

public class PsqlSgbdExceptionFactory : ISgbdExceptionFactory
{
    public SgbdException Create(Exception exception)
    {
        throw new NotImplementedException();
    }
}