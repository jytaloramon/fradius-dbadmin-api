using RadiusDomain.User.Entities;

namespace RadiusDomain.User.Repositories.Interfaces;

public interface IRadiusUserAttributeRepository
{
    public List<RadiusUserAttribute> GetAllAttributes();

    public RadiusUserAttributeGroup? GetGroupByName(string name);
    
    public List<RadiusUserAttributeGroup> GetAllGroups();
    
    
}