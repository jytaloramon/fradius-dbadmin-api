using System.Collections.Immutable;
using RadiusDomain.User.Entities;
using RadiusDomain.User.UseCases.Interfaces;

namespace RadiusDomain.User.UseCases;

public class RadiusUserAttributeUseCases : IRadiusUserAttributeUseCases
{
    public ImmutableDictionary<string, string> GetAllAttributes()
    {
        return RadiusUserAttribute.GetInstance().Attributes;
    }

    public ImmutableDictionary<string, HashSet<string>> GetAllGroups()
    {
        return RadiusUserAttribute.GetInstance().AttributeGroups;
    }
}