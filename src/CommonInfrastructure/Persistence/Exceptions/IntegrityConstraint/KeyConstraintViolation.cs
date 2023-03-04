using Infrastructure.Persistence.Exceptions.Entities;

namespace Infrastructure.Persistence.Exceptions.IntegrityConstraint;

public class KeyConstraintViolation : SgbdException
{
    public KeyConstraintViolation(string property, string message) : base(property, message)
    {
    }
}