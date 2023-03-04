using Infrastructure.Persistence.Exceptions.Entities;

namespace Infrastructure.Persistence.Exceptions.IntegrityConstraint;

public class UniqueConstraintViolation : SgbdException
{
    public UniqueConstraintViolation(string property, string message) : base(property, message)
    {
    }
}