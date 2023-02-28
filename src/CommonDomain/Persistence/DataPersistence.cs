namespace CommonDomain.Persistence;

public abstract class DataPersistence<T>
{
    protected DataPersistence(T repository)
    {
        Repository = repository;
    }

    public T Repository { get; init; }
}