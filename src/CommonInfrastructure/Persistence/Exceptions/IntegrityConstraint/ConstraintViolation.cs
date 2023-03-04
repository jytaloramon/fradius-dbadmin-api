using Infrastructure.Persistence.Exceptions.Entities;

namespace Infrastructure.Persistence.Exceptions.IntegrityConstraint;

public class ConstraintViolation : SgbdException
{
    public ConstraintViolation(string property, string message) : base(property, message)
    {
    }
}