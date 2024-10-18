using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Regies.Application.Regies;
using Regies.Application.Regies.Commands.CreateRegie;
using Regies.Application.Regies.Commands.UpdateRegie;
using Regies.Application.Regies.DTOs;
using Regies.Application.Regies.Querys.GetAllRegies;
using Regies.Application.Regies.Querys.GetRegieById;
using Regies.Infrastructure.Constants;

namespace Regies.API.Controllers;

/// <summary>
/// Contrôleur pour les opérations liées aux régies.
/// </summary>
/// <remarks>
/// Initialise une nouvelle instance de la classe <see cref="RegiesController"/>.
/// </remarks>
/// <param name="mediator">Le médiateur.</param>
[ApiController]
[Route("api/[controller]")]
[Authorize]
public class RegiesController(IMediator mediator) : ControllerBase
{

    /// <summary>
    /// Obtient toutes les régies.
    /// </summary>
    /// <returns>Une action résultant en une liste de DTO de régies.</returns>
    /// <response code="200">Retourne la liste des régies.</response>
    [HttpGet]
    [AllowAnonymous]
    public async Task<ActionResult<IEnumerable<RegieDto>>> GetAllRegies()
    {
        var regies = await mediator.Send(new GetAllRegiesQuery());
        return Ok(regies);
    }

    /// <summary>
    /// Obtient une régie par son identifiant.
    /// </summary>
    /// <param name="id">L'identifiant de la régie.</param>
    /// <returns>Une action résultant en un DTO de régie.</returns>
    /// <response code="200">Retourne la régie.</response>
    /// <response code="404">Si la régie n'existe pas.</response>
    [HttpGet("{id}")]
    [Authorize(Policy = PolicyNames.s_HasNationality)]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(RegieDto))]
    [ProducesResponseType(404, StatusCode = StatusCodes.Status404NotFound)]
    public async Task<ActionResult<RegieDto?>> GetById([FromRoute] int id)
    {
        var regie = await mediator.Send(new GetRegieByIdQuery(id));
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
    /// <response code="201">La régie a été créée.</response>
    /// <response code="400">Si la commande est invalide.</response>
    [HttpPost("create")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> CreateRegie([FromBody] CreateRegieCommand createRegieCommand)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        int regieId = await mediator.Send(createRegieCommand);
        return CreatedAtAction(nameof(GetById), new { id = regieId }, null);
    }

    /// <summary>
    /// Met à jour une régie existante.
    /// </summary>
    /// <param name="id">L'identifiant de la régie à mettre à jour.</param>
    /// <param name="updateRegieCommand">La commande de mise à jour de la régie.</param>
    /// <returns>Une action résultant en un code de statut HTTP.</returns>
    /// <response code="204">La régie a été mise à jour avec succès.</response>
    /// <response code="400">Si la commande est invalide.</response>
    [HttpPatch("{id}")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> UpdateRegie([FromRoute] int id, [FromBody] UpdateRegieCommand updateRegieCommand)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        updateRegieCommand.Id = id;
        await mediator.Send(updateRegieCommand);
        return NoContent();
    }
}
