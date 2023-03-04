using Infrastructure.Persistence.Exceptions.Entities;

namespace Infrastructure.Persistence.Db.Interfaces;

public interface IDataPersistence<out T>
{
    public T GetRepositoryData();

    public SgbdException HandlerException(Exception exceptions);
}