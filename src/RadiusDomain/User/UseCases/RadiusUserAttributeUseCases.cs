using RadiusDomain.User.Entities;
using RadiusDomain.User.Repositories.Interfaces;
using RadiusDomain.User.UseCases.Interfaces;

namespace RadiusDomain.User.UseCases;

public class RadiusUserAttributeUseCases : IRadiusUserAttributeUseCases
{
    private readonly IRadiusUserAttributeRepository _repository;

    public RadiusUserAttributeUseCases(IRadiusUserAttributeRepository repository)
    {
        _repository = repository;
    }

    public RadiusUserAttributeGroup? GetGroupByName(string name)
    {
        return _repository.GetGroupByName(name);
    }

    public List<RadiusUserAttributeGroup> GetAllGroups()
    {
        return _repository.GetAllGroups();
    }
}