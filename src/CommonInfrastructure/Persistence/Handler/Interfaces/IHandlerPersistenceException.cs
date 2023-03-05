using CommonInfrastructure.Persistence.Exceptions;

namespace CommonInfrastructure.Persistence.Handler.Interfaces;

public interface IHandlerPersistenceException
{
    public SgbdException Handler(Exception exception);
}