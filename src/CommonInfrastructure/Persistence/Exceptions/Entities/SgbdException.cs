namespace Infrastructure.Persistence.Exceptions.Entities;

public class SgbdException : Exception
{
    public SgbdException(string property, string message) : base(message)
    {
        Property = property;
    }

    public SgbdException(string property, string? message, Exception? innerException) : base(message, innerException)
    {
    }

    public string Property { get; init; }
}