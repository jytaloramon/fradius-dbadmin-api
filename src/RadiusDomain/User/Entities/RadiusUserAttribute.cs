using System.Collections.Immutable;

namespace RadiusDomain.User.Entities;

public class RadiusUserAttribute
{
    private static RadiusUserAttribute? _instance;

    private static readonly object ObjectLock = new int();

    private RadiusUserAttribute(ImmutableDictionary<string, string> attributes)
    {
        AttributeGroups = MakeGroups(attributes);
        Attributes = attributes;
    }

    public ImmutableDictionary<string, HashSet<string>> AttributeGroups { get; init; }

    public ImmutableDictionary<string, string> Attributes { get; init; }

    public static RadiusUserAttribute GetInstance()
    {
        if (_instance == null)
        {
            lock (ObjectLock)
            {
                if (_instance == null)
                {
                    _instance = new RadiusUserAttribute(MakeAttributes());
                }
            }
        }

        return _instance!;
    }

    public bool IsSameGroup(string attr1, string attr2)
    {
        if (!Attributes.ContainsKey(attr1) || !Attributes.ContainsKey(attr2))
        {
            return false;
        }

        return Attributes[attr1].Equals(Attributes[attr2]);
    }

    private static ImmutableDictionary<string, string> MakeAttributes()
    {
        var attributes = new Dictionary<string, string>
        {
            { "Cleartext-Password", "Password" },
            { "MD5-Password", "Password" },
            { "SHA2-Password", "Password" },
            { "Crypt-Password", "Password" },
            { "Type-Accept", "Accept"}
        };

        return attributes.ToImmutableDictionary();
    }

    private static ImmutableDictionary<string, HashSet<string>> MakeGroups(
        ImmutableDictionary<string, string> attributes)
    {
        var groups = new Dictionary<string, HashSet<string>>();

        foreach (var attr in attributes)
        {
            if (!groups.ContainsKey(attr.Value))
            {
                groups.Add(attr.Value, new HashSet<string>());
            }

            groups[attr.Value].Add(attr.Key);
        }

        return groups.ToImmutableDictionary();
    }
}