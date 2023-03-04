namespace Infrastructure.Persistence.Exceptions.Entities;

public abstract class SgbdException : Exception
{
    protected SgbdException(string property, string message) : base(message)
    {
        Property = property;
    }

    public string Property { get; init; }
}