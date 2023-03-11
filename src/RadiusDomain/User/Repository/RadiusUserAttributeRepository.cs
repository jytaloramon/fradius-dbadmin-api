using System.Collections.Immutable;
using RadiusDomain.User.Entities;
using RadiusDomain.User.Repository.Interfaces;

namespace RadiusDomain.User.Repository;

public class RadiusUserAttributeRepository : IRadiusUserAttributeRepository
{
    private readonly ImmutableDictionary<string, RadiusUserAttribute> _attributes;

    private readonly ImmutableDictionary<string, RadiusUserAttributeGroup> _groups;

    public RadiusUserAttributeRepository(IEnumerable<RadiusUserAttribute> attributes)
    {
        _attributes = MakeDictionaryAttributes(attributes);
        _groups = MakeDictionaryGroups(_attributes);
    }

    public List<RadiusUserAttribute> GetAllAttributes()
    {
        return _attributes.Values.ToList();
    }

    public RadiusUserAttributeGroup? GetGroupByName(string name)
    {
        return _groups.ContainsKey(name) ? _groups[name] : null;
    }

    public List<RadiusUserAttributeGroup> GetAllGroups()
    {
        return _groups.Values.ToList();
    }

    private ImmutableDictionary<string, RadiusUserAttribute> MakeDictionaryAttributes(
        IEnumerable<RadiusUserAttribute> attributes)
    {
        return attributes.ToImmutableDictionary(attr => attr.Name, attr => attr);
    }

    private ImmutableDictionary<string, RadiusUserAttributeGroup> MakeDictionaryGroups(
        ImmutableDictionary<string, RadiusUserAttribute> attributes)
    {
        var newDicGroups = new Dictionary<string, List<string>>();

        foreach (var attr in attributes.Values)
        {
            if (!newDicGroups.ContainsKey(attr.GroupName))
            {
                newDicGroups.Add(attr.GroupName, new List<string>());
            }

            newDicGroups[attr.GroupName].Add(attr.Name);
        }

        return newDicGroups.ToImmutableDictionary(g => g.Key, g => new RadiusUserAttributeGroup(g.Key, g.Value));
    }
}