using RadiusDomain.User.Entities;

namespace RadiusDomainUnitTests.User.Entities;

public class RadiusUserAttributeGroupUnitTests
{
    private readonly RadiusUserAttributeGroup _radiusUserAttribute;

    public RadiusUserAttributeGroupUnitTests()
    {
        _radiusUserAttribute = new RadiusUserAttributeGroup("Test",
            new[] { "Attr1", "Attr1", "Attr2", "Attr2", "Attr3" });
    }

    [Fact]
    public void Constructor_DuplicateInput_ReturnAttrListWithoutDuplicates()
    {
        var actualAttrList = _radiusUserAttribute.Attributes.ToList();
        actualAttrList.Sort();

        Assert.Equal(3, actualAttrList.Count);
        Assert.Equal(new[] { "Attr1", "Attr2", "Attr3" }, actualAttrList);
    }

    [Fact]
    public void IsFromGroup_NonExistentAttr_ReturnFalse()
    {
        var actual = _radiusUserAttribute.IsFromGroup("Attr0");

        Assert.False(actual);
    }

    [Theory]
    [InlineData("Attr1")]
    [InlineData("Attr2")]
    [InlineData("Attr3")]
    public void IsFromGroup_ExistentAttr_ReturnTrue(string attr)
    {
        var actual = _radiusUserAttribute.IsFromGroup(attr);

        Assert.True(actual);
    }
}