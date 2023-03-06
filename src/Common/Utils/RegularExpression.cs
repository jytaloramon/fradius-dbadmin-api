namespace Common.Utils;

public static class RegularExpression
{
    public const string CommonName = @"^[a-zA-Z\u00C0-\u00FF](\s?[a-zA-Z\u00C0-\u00FF]+)*$";

    public const string Username = @"^[a-zA-Z0-9](\.?[a-zA-Z0-9]+)*$";

    public const string GeneralUseName = @"^[a-zA-Z0-9_-]+$";

    public const string WordWithoutWhiteSpace = @"^[^\s]+$";
}