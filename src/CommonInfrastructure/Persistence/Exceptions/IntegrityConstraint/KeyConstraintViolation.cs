using CommonInfrastructure.Persistence.Exceptions.Entities;

namespace CommonInfrastructure.Persistence.Exceptions.IntegrityConstraint;

public class KeyConstraintViolation : SgbdException
{
    public KeyConstraintViolation(string property, string message) : base(property, message)
    {
    }
}