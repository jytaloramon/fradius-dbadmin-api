namespace RadiusDomain.User.Entities;

public class RadiusUserAttribute
{
    public RadiusUserAttribute(string name, string groupName)
    {
        Name = name;
        GroupName = groupName;
    }

    public string Name { get; init; }

    public string GroupName { get; init; }
}