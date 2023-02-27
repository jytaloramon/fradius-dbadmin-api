namespace FradiusDomain.Common.Repository;

public interface IDataRepositoryPool
{
    public DataRepository GetRepository();
}