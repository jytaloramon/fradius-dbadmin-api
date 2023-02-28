namespace CommonDomain.Repository;

public interface IInsertRepository<in T>
{
    public Task Insert(T t);
}