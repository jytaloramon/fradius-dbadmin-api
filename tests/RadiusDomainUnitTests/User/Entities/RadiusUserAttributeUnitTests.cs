using RadiusDomain.User.Entities;

namespace RadiusDomainUnitTests.User.Entities;

public class RadiusUserAttributeUnitTests
{
    [Fact]
    public void GetInstance_MultipleCall_ReturnSameInstance()
    {
        var radiusUserAttrExpected = RadiusUserAttribute.GetInstance();
        var radiusUserAttrActual = RadiusUserAttribute.GetInstance();

        Assert.Equal(radiusUserAttrExpected, radiusUserAttrActual);
    }

    [Theory]
    [InlineData("Cleartext-Password", "MD5-Password")]
    public void IsSameGroup_TwoValuesSameGroup_ReturnTrue(string attr1, string attr2)
    {
        var radiusUserAttribute = RadiusUserAttribute.GetInstance();
        
        Assert.True(radiusUserAttribute.IsSameGroup(attr1, attr2));
    }
    
    [Theory]
    [InlineData("Cleartext-Password", "Type-Accept")]
    [InlineData("", "Type-Accept")]
    public void IsSameGroup_TwoValuesDifferentGroup_ReturnTrue(string attr1, string attr2)
    {
        var radiusUserAttribute = RadiusUserAttribute.GetInstance();
        
        Assert.False(radiusUserAttribute.IsSameGroup(attr1, attr2));
    }
}