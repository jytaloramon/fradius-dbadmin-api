namespace Common.Exceptions;

public class EntityValidationException : Exception
{
    public EntityValidationException(IDictionary<string, string[]> errors) : base()
    {
        Errors = errors;
    }

    public IDictionary<string, string[]> Errors { get; init; }
}