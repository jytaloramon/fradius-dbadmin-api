namespace CommonDomain.Persistence.Interfaces;

public interface IDataPersistence<out T>
{
    public T GetRepositoryData();
}