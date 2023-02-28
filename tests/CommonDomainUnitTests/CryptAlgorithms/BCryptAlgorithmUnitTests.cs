using CommonDomain.CryptAlgorithms;

namespace CommonDomainUnitTests.CryptAlgorithms;

public class BCryptAlgorithmUnitTests
{
    [Theory]
    [InlineData("")]
    [InlineData("Mike")]
    [InlineData("testtest")]
    public void GenHash(string content)
    {
        var hashContent = BCryptAlgorithm.GenHash(content);

        Assert.Matches(@"^\$.+\$.+$", hashContent);
    }

    [Theory]
    [InlineData("")]
    [InlineData("Mike")]
    [InlineData("testtest")]
    public void Compare(string content)
    {
        var hashContent = BCryptAlgorithm.GenHash(content);

        Assert.True(BCryptAlgorithm.Compare(content, hashContent));
    }
}