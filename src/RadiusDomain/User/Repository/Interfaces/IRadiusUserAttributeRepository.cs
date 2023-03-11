using RadiusDomain.User.Entities;

namespace RadiusDomain.User.Repository.Interfaces;

public interface IRadiusUserAttributeRepository
{
    public List<RadiusUserAttribute> GetAllAttributes();

    public List<RadiusUserAttributeGroup> GetAllGroups();
    
    
}