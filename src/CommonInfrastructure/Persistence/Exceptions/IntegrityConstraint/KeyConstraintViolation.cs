namespace Infrastructure.Persistence.Exceptions.IntegrityConstraint;

public class KeyConstraintViolation : ConstraintViolation
{
    public KeyConstraintViolation(IDictionary<string, string[]> errors) : base(errors)
    {
    }

    public KeyConstraintViolation(IDictionary<string, string[]> errors, Exception? innerException)
        : base(errors, innerException)
    {
    }
}