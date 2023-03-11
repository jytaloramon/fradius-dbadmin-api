using RadiusDomain.User.Entities;
using RadiusDomain.User.Presentation.Models;

namespace RadiusDomain.User.UseCases.Interfaces;

public interface IRadiusUserAttributeUseCases
{
    public RadiusUserAttributeGroupRecord? GetGroupByName(string name);

    public List<RadiusUserAttributeGroupRecord> GetAllGroups();
}