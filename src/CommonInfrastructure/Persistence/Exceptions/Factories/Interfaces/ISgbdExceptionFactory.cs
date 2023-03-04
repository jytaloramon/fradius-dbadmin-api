using Infrastructure.Persistence.Exceptions.Entities;

namespace Infrastructure.Persistence.Exceptions.Factories.Interfaces;

public interface ISgbdExceptionFactory
{
    public SgbdException Create(Exception exception);
}