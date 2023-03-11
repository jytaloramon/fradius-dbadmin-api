using RadiusDomain.User.Entities;

namespace RadiusDomain.User.UseCases.Interfaces;

public interface IRadiusUserAttributeUseCases
{
    public RadiusUserAttributeGroup? GetGroupByName(string name);

    public List<RadiusUserAttributeGroup> GetAllGroups();
}