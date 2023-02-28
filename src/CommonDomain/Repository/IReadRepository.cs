namespace CommonDomain.Repository;

public interface IReadRepository<T>
{
    public Task<T?> GetById(int id);
    
    public Task<List<T>> GetAll();
}