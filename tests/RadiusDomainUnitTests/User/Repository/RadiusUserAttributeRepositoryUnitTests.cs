using RadiusDomain.User.Entities;
using RadiusDomain.User.Repository;

namespace RadiusDomainUnitTests.User.Repository;

public class RadiusUserAttributeRepositoryUnitTests
{
    [Fact]
    public void GetAllAttributes_TwoEntityInput_ReturnAttrListWithTwoEntity()
    {
        var repository = new RadiusUserAttributeRepository(new[]
        {
            new RadiusUserAttribute("Attr1", "Group1"),
            new RadiusUserAttribute("Attr2", "Group2"),
        });

        var actualAttrList = repository.GetAllAttributes();
        actualAttrList.Sort((o1, o2) => string.Compare(o1.Name, o2.Name, StringComparison.Ordinal));

        var actualAttr1 = actualAttrList[0];
        var actualAttr2 = actualAttrList[1];

        Assert.Equal(2, actualAttrList.Count);
        Assert.Equal("Attr1", actualAttr1.Name);
        Assert.Equal("Attr2", actualAttr2.Name);
    }

    [Fact]
    public void GetGroupByName_NonExistentGroup_ReturnNull()
    {
        var repository = new RadiusUserAttributeRepository(new[] { new RadiusUserAttribute("Attr1", "Group1") });

        var actualGroup = repository.GetGroupByName("AttrNonExistent");

        Assert.Null(actualGroup);
    }

    [Fact]
    public void GetGroupName_ExistentGroup_ReturnEntity()
    {
        var repository = new RadiusUserAttributeRepository(new[]
        {
            new RadiusUserAttribute("Attr1", "Group1"),
        });

        var actualGroup = repository.GetGroupByName("Group1");

        Assert.NotNull(actualGroup);
    }

    [Fact]
    public void GetAllGroups_SameGroupInput_ReturnSingleList()
    {
        var repository = new RadiusUserAttributeRepository(new[]
        {
            new RadiusUserAttribute("Attr1", "Group1"),
            new RadiusUserAttribute("Attr2", "Group1"),
        });

        var actualGroupList = repository.GetAllGroups();
        var actualAttrList = actualGroupList[0];

        Assert.Single(actualGroupList);
        Assert.Equal(2, actualAttrList.Attributes.Count);
    }

    [Fact]
    public void GetAllGroups_TwoGroupInput_ReturnList()
    {
        var repository = new RadiusUserAttributeRepository(new[]
        {
            new RadiusUserAttribute("Attr1", "Group1"),
            new RadiusUserAttribute("Attr2", "Group1"),
            new RadiusUserAttribute("Attr3", "Group2"),
        });

        var actualGroupList = repository.GetAllGroups();

        Assert.Equal(2, actualGroupList.Count);
    }
}