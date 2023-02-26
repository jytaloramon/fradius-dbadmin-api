namespace Crypt.Algorithms;

public static class BCryptAlgorithm
{
    public static string GetHashPassword(string password)
    {
        return BCrypt.Net.BCrypt.HashPassword(password);
    }

    public static bool IsEqual(string password, string hash)
    {
        return BCrypt.Net.BCrypt.Verify(password, hash);
    }
}