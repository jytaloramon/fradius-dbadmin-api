namespace Infrastructure.Persistence.Exceptions.IntegrityConstraint;

public class CheckConstraintViolation : ConstraintViolation
{
    public CheckConstraintViolation(IDictionary<string, string[]> errors) : base(errors)
    {
    }

    public CheckConstraintViolation(IDictionary<string, string[]> errors, Exception? innerException)
        : base(errors, innerException)
    {
    }
}