using Common.Exceptions;

namespace Infrastructure.Persistence.Exceptions.Factories.Interfaces;

public interface ISgbdExceptionFactory
{
    public BaseException Create(Exception exception);
}