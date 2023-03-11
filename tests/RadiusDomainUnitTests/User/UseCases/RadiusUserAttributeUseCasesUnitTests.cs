using Moq;
using RadiusDomain.User.UseCases;
using RadiusDomain.User.Entities;
using RadiusDomain.User.Presentation;
using RadiusDomain.User.Repositories.Interfaces;

namespace RadiusDomainUnitTests.User.UseCases;

public class RadiusUserAttributeUseCasesUnitTests
{
    [Fact]
    public void GetGroupByName_NameFound_ReturnRadiusUserAttributeGroup()
    {
        var repository = new Mock<IRadiusUserAttributeRepository>();
        repository.Setup(attributeRepository => attributeRepository.GetGroupByName("Group1"))
            .Returns(new RadiusUserAttributeGroup("Group1", new[] { "" }));

        var userCases = new RadiusUserAttributeUseCases(repository.Object, new RadiusUserAttributePresentation());

        var actual = userCases.GetGroupByName("Group1");

        Assert.NotNull(actual);
    }

    [Fact]
    public void GetGroupByName_NameNotFound_ReturnNull()
    {
        var repository = new Mock<IRadiusUserAttributeRepository>();
        repository.Setup(attributeRepository => attributeRepository.GetGroupByName("Group1"))
            .Returns((RadiusUserAttributeGroup?)null);

        var userCases = new RadiusUserAttributeUseCases(repository.Object, new RadiusUserAttributePresentation());

        var actual = userCases.GetGroupByName("Group1");

        Assert.Null(actual);
    }

    [Fact]
    public void GetAllGroups_ReturnRadiusUserAttributeGroupList()
    {
        var repository = new Mock<IRadiusUserAttributeRepository>();
        repository.Setup(attributeRepository => attributeRepository.GetAllGroups())
            .Returns(new List<RadiusUserAttributeGroup>() { new RadiusUserAttributeGroup("Group1", new[] { "" }) });

        var userCases = new RadiusUserAttributeUseCases(repository.Object, new RadiusUserAttributePresentation());

        var actual = userCases.GetAllGroups();

        Assert.Single(actual);
    }
}