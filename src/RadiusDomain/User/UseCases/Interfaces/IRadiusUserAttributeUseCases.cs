using System.Collections.Immutable;

namespace RadiusDomain.User.UseCases.Interfaces;

public interface IRadiusUserAttributeUseCases
{
    public ImmutableDictionary<string, string> GetAllAttributes();
    
    public ImmutableDictionary<string, HashSet<string>> GetAllGroups();
}