using CommonInfrastructure.Persistence.Exceptions.Entities;

namespace CommonInfrastructure.Persistence.Handler.Interfaces;

public interface IHandlerPersistenceException
{
    public SgbdException Handler(Exception exception);
}