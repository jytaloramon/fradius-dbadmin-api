namespace RadiusDomain.User.Entities;

public class UserAttribute
{
    public int Id { get; set; }

    public string Username { get; set; } = "";

    public string Attribute { get; set; } = "";

    public string Operation { get; set; } = "";

    public string Value { get; set; } = "";
}