namespace CommonInfrastructure.Persistence.Exceptions.IntegrityConstraint;

public class ConstraintViolation : SgbdException
{
    public ConstraintViolation(string property, string message) : base(property, message)
    {
    }
}