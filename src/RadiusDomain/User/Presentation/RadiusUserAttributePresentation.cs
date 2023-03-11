using RadiusDomain.User.Entities;
using RadiusDomain.User.Presentation.Interfaces;
using RadiusDomain.User.Presentation.Models;

namespace RadiusDomain.User.Presentation;

public class RadiusUserAttributePresentation : IRadiusUserAttributePresentation
{
    public RadiusUserAttributeGroupRecord? GetGroupByName(RadiusUserAttributeGroup? radiusUserAttributeGroup)
    {
        if (radiusUserAttributeGroup == null)
        {
            return null;
        }

        return new RadiusUserAttributeGroupRecord(radiusUserAttributeGroup.Name,
            radiusUserAttributeGroup.Attributes.ToList());
    }

    public List<RadiusUserAttributeGroupRecord> GetAllGroups(List<RadiusUserAttributeGroup> radiusUserAttributeGroups)
    {
        return radiusUserAttributeGroups
            .Select(group => new RadiusUserAttributeGroupRecord(group.Name, group.Attributes.ToList())).ToList();
    }
}