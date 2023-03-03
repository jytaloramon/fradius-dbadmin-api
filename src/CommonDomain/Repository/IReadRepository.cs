namespace CommonDomain.Repository;

public interface IReadRepository<T>
{
    public T? GetById(int id);

    public List<T> GetAll();
}