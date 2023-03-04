using CommonInfrastructure.Persistence.Exceptions.Entities;

namespace CommonInfrastructure.Persistence.Exceptions.Factories.Interfaces;

public interface ISgbdExceptionFactory
{
    public SgbdException Create(Exception exception);
}