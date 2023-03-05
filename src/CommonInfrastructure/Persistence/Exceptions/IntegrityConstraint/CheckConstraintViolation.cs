namespace CommonInfrastructure.Persistence.Exceptions.IntegrityConstraint;

public class CheckConstraintViolation : SgbdException
{
    public CheckConstraintViolation(string property, string message) : base(property, message)
    {
    }
}