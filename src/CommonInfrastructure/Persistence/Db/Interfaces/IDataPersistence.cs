using CommonInfrastructure.Persistence.Exceptions.Entities;

namespace CommonInfrastructure.Persistence.Db.Interfaces;

public interface IDataPersistence<out T>
{
    public T GetRepositoryData();

    public SgbdException HandlerException(Exception exceptions);
}