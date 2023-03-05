using CommonInfrastructure.Persistence.Exceptions;

namespace CommonDomain.Repository;

public interface IInsertRepository<in T>
{
    /**
     * <exception cref="SgbdException"></exception>
     */
    public int Insert(T t);
}