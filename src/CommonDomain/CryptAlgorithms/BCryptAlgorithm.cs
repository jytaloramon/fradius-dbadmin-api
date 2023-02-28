namespace CommonDomain.CryptAlgorithms;

public static class BCryptAlgorithm
{
    public static string GenHash(string content)
    {
        return BCrypt.Net.BCrypt.HashPassword(content);
    }

    public static bool Compare(string content, string hash)
    {
        return BCrypt.Net.BCrypt.Verify(content, hash);
    }
}