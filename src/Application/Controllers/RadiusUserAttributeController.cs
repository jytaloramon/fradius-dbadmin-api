using Application.Models.Universal;
using Microsoft.AspNetCore.Mvc;
using RadiusDomain.User.Presentation.Models;
using RadiusDomain.User.UseCases.Interfaces;

namespace Application.Controllers;

[ApiController]
[Route("api/radiusattr/group")]
public class RadiusUserAttributeController : ControllerBase
{
    private readonly IRadiusUserAttributeUseCases _useCases;

    public RadiusUserAttributeController(IRadiusUserAttributeUseCases useCases)
    {
        _useCases = useCases;
    }

    [HttpGet("{name}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(RadiusUserAttributeGroupRecord))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(GenericMessage))]
    public ActionResult GetByName(string name)
    {
        var attributeGroup = _useCases.GetGroupByName(name);

        if (attributeGroup == null)
        {
            return NotFound(new GenericMessage($"Group name not found: \"{name}\""));
        }

        return Ok(attributeGroup);
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<RadiusUserAttributeGroupRecord>))]
    public ActionResult Get()
    {
        return Ok(_useCases.GetAllGroups());
    }
}