using MediatR;
using Microsoft.AspNetCore.Mvc;
using Regies.Application.Regies;
using Regies.Application.Regies.Commands.CreateRegie;
using Regies.Application.Regies.DTOs;
using Regies.Application.Regies.Querys.GetAllRegies;
using Regies.Application.Regies.Querys.GetRegieById;

namespace Regies.API.Controllers;

/// <summary>
/// Contrôleur pour les opérations liées aux régies.
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class RegiesController : ControllerBase
{
    private readonly IRegieService _service;
    private readonly IMediator _mediator;

    /// <summary>
    /// Initialise une nouvelle instance de la classe <see cref="RegiesController"/>.
    /// </summary>
    /// <param name="service">Le service de régies.</param>
    /// <param name="mediator">Le médiateur.</param>
    public RegiesController(IRegieService service, IMediator mediator)
    {
        _service = service;
        _mediator = mediator;
    }

    /// <summary>
    /// Obtient toutes les régies.
    /// </summary>
    /// <returns>Une action résultant en une liste de DTO de régies.</returns>
    [HttpGet]
    //[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<RegieDto>))]
    public async Task<ActionResult<IEnumerable<RegieDto>>> GetAllRegies()
    {
        var regies = await _mediator.Send(new GetAllRegiesQuery());
        return Ok(regies);
    }

    /// <summary>
    /// Obtient une régie par son identifiant.
    /// </summary>
    /// <param name="id">L'identifiant de la régie.</param>
    /// <returns>Une action résultant en un DTO de régie.</returns>
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(RegieDto))]
    [ProducesResponseType(404, StatusCode = StatusCodes.Status404NotFound)]
    public async Task<ActionResult<RegieDto?>> GetById([FromRoute] int id)
    {
        var regie = await _mediator.Send(new GetRegieByIdQuery(id));
        if (regie == null)
        {
            return NotFound();
        }
        return Ok(regie);
    }

    /// <summary>
    /// Crée une nouvelle régie.
    /// </summary>
    /// <param name="createRegieCommand">La commande de création de régie.</param>
    /// <returns>Une action résultant en un code de statut HTTP.</returns>
    [HttpPost("create")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> CreateRegie([FromBody] CreateRegieCommand createRegieCommand)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        int regieId = await _mediator.Send(createRegieCommand);
        return CreatedAtAction(nameof(GetById), new { id = regieId }, null);
    }
}
