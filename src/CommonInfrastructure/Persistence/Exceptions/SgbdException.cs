namespace CommonInfrastructure.Persistence.Exceptions;

public class SgbdException : Exception
{
    public SgbdException(string property, string message) : base(message)
    {
        Property = property;
    }

    public SgbdException(string property, string? message, Exception? innerException) : base(message, innerException)
    {
        Property = property;
    }

    public string Property { get; init; }
}