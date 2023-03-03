namespace CommonDomain.Repository;

public interface IInsertRepository<in T>
{
    public void Insert(T t);
}