namespace FradiusDomainUnitTests.CommonUtils;

public static class GenerateTestId
{
    public const int IntMax = 1_000_000;

    public const int LongMax = 100_000_000;
    
    public static int GenInt()
    {
        return (int)GenLong();
    }

    public static int GenInt(int max)
    {
        var valueGen = (int)GenLong();

        return valueGen % max;
    }

    public static long GenLong()
    {
        return Random.Shared.NextInt64();
    }

    public static long GenLong(long max)
    {
        return Random.Shared.NextInt64() % max;
    }
}