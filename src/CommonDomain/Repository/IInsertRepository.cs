namespace CommonDomain.Repository;

public interface IInsertRepository<in T>
{
    public int Insert(T t);
}