using Common.Exceptions;
using CommonInfrastructure.Persistence.Exceptions;
using CommonInfrastructure.Persistence.Exceptions.IntegrityConstraint;

namespace CommonDomain.Handlers;

public static class UseCasesHandlerSgbdException
{
    public static BaseException Handler(SgbdException exception)
    {
        var dictionaryErrors = new Dictionary<string, string[]>()
        {
            [exception.Property] = new[] { exception.Message }
        };

        return exception switch
        {
            ConstraintViolationSgbdException => new EntityValidationException(dictionaryErrors),
            _ => new BaseException(dictionaryErrors)
        };
    }
}