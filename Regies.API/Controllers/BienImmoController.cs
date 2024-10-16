using MediatR;
using Microsoft.AspNetCore.Mvc;
using Regies.Application.BienImmobiliers.Commands.CreateBienImmo;
using Regies.Application.BienImmobiliers.DTOs;
using Regies.Application.BienImmobiliers.Querys;
using Regies.Domain.Model;

namespace Regies.API.Controllers;

/// <summary>
/// Contrôleur pour les biens immobiliers.
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class BienImmoController(IMediator _mediator) : ControllerBase
{

    /// <summary>
    /// Obtient tous les biens immobiliers.
    /// </summary>
    /// <returns>Une action résultant en une liste de biens immobiliers.</returns>
    [HttpGet("all")]
    public async Task<IActionResult> GetAll()
    {
        var bienImmos =  await _mediator.Send(new GetAllBienImmoQuery());

        return Ok(bienImmos);
    }

    [HttpPost("create")]
    public async Task<IActionResult> Create([FromBody] CreateBienImmoCommand command)
    {
        var id = await _mediator.Send(command);
         return CreatedAtAction(nameof(GetAll), new { id = id }, null);
    }
}
