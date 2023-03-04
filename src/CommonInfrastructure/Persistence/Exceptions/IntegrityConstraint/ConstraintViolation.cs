using Common.Exceptions;

namespace Infrastructure.Persistence.Exceptions.IntegrityConstraint;

public class ConstraintViolation : BaseException
{
    public ConstraintViolation(IDictionary<string, string[]> errors) : base(errors)
    {
    }

    public ConstraintViolation(IDictionary<string, string[]> errors, Exception? innerException)
        : base(errors, innerException)
    {
    }
}