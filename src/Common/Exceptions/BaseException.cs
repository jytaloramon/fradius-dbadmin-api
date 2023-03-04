namespace Common.Exceptions;

public class BaseException : Exception
{
    public BaseException(IDictionary<string, string[]> errors)
    {
        Errors = errors;
    }

    public BaseException(IDictionary<string, string[]> errors, Exception? innerException) : base(null, innerException)
    {
        Errors = errors;
    }

    public IDictionary<string, string[]> Errors { get; init; }
}