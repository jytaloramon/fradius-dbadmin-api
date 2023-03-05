namespace Common.Exceptions;

public class EntityValidationException : BaseException
{
    public EntityValidationException(IDictionary<string, string[]> errors) : base(errors)
    {
    }

    public EntityValidationException(IDictionary<string, string[]> errors, Exception? innerException) : base(errors, innerException)
    {
    }
}