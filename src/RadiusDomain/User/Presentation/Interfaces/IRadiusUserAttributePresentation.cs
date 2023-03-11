using RadiusDomain.User.Entities;
using RadiusDomain.User.Presentation.Models;

namespace RadiusDomain.User.Presentation.Interfaces;

public interface IRadiusUserAttributePresentation
{
    public RadiusUserAttributeGroupRecord? GetGroupByName(RadiusUserAttributeGroup? radiusUserAttributeGroup);

    public List<RadiusUserAttributeGroupRecord> GetAllGroups(List<RadiusUserAttributeGroup> radiusUserAttributeGroups);
}