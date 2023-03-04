using CommonInfrastructure.Persistence.Exceptions.Entities;

namespace CommonInfrastructure.Persistence.Exceptions.IntegrityConstraint;

public class UniqueConstraintViolation : SgbdException
{
    public UniqueConstraintViolation(string property, string message) : base(property, message)
    {
    }
}