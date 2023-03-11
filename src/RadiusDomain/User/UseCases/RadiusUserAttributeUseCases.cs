using RadiusDomain.User.Entities;
using RadiusDomain.User.Presentation.Interfaces;
using RadiusDomain.User.Presentation.Models;
using RadiusDomain.User.Repositories.Interfaces;
using RadiusDomain.User.UseCases.Interfaces;

namespace RadiusDomain.User.UseCases;

public class RadiusUserAttributeUseCases : IRadiusUserAttributeUseCases
{
    private readonly IRadiusUserAttributeRepository _repository;

    private readonly IRadiusUserAttributePresentation _presentation;

    public RadiusUserAttributeUseCases(IRadiusUserAttributeRepository repository,
        IRadiusUserAttributePresentation presentation)
    {
        _repository = repository;
        _presentation = presentation;
    }

    public RadiusUserAttributeGroupRecord? GetGroupByName(string name)
    {
        return _presentation.GetGroupByName(_repository.GetGroupByName(name));
    }

    public List<RadiusUserAttributeGroupRecord> GetAllGroups()
    {
        return _presentation.GetAllGroups(_repository.GetAllGroups());
    }
}