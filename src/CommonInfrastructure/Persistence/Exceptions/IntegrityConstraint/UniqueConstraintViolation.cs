namespace Infrastructure.Persistence.Exceptions.IntegrityConstraint;

public class UniqueConstraintViolation : ConstraintViolation
{
    public UniqueConstraintViolation(IDictionary<string, string[]> errors) : base(errors)
    {
    }

    public UniqueConstraintViolation(IDictionary<string, string[]> errors, Exception? innerException)
        : base(errors, innerException)
    {
    }
}