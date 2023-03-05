namespace CommonInfrastructure.Persistence.Exceptions.IntegrityConstraint;

public class ConstraintViolationSgbdException : SgbdException
{
    public ConstraintViolationSgbdException(string property, string message) : base(property, message)
    {
    }
}