namespace FradiusDomain.Common.Repository;

public interface IInsertRepository<T>
{
    public Task Insert(T t);
}