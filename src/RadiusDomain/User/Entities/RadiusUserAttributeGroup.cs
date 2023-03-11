using System.Collections.Immutable;

namespace RadiusDomain.User.Entities;

public class RadiusUserAttributeGroup
{
    private readonly HashSet<string> _attributes;

    public RadiusUserAttributeGroup(string name, IEnumerable<string> attributes)
    {
        Name = name;
        _attributes = attributes.ToHashSet();
    }

    public string Name { get; init; }

    public ImmutableList<string> Attributes => _attributes.ToImmutableList();

    public bool IsFromGroup(string attr)
    {
        return _attributes.Contains(attr);
    }
}