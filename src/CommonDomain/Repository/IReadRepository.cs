using CommonInfrastructure.Persistence.Exceptions;

namespace CommonDomain.Repository;

public interface IReadRepository<T>
{
    /**
     * <exception cref="SgbdException"></exception>
     */
    public T? GetById(int id);

    /**
     * <exception cref="SgbdException"></exception>
     */
    public List<T> GetAll();
}