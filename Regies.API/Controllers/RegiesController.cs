using MediatR;
using Microsoft.AspNetCore.Mvc;
using Regies.Application.Regies;
using Regies.Application.Regies.Commands.CreateRegie;
using Regies.Application.Regies.DTOs;
using Regies.Application.Regies.Querys.GetAllRegies;
using Regies.Application.Regies.Querys.GetRegieById;

namespace Regies.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RegiesController(IRegieService service, IMediator _mediator) :  ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllRegies()
    {
        var regies = await _mediator.Send(new GetAllRegiesQuery());
        return Ok(regies);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute]int id)
    {
        var regie = await _mediator.Send(new GetRegieByIdQuery(id));
        if (regie == null)
        {
            return NotFound();
        }
        return Ok(regie);
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateRegie([FromBody] CreateRegieCommand createRegieCommand)
    {
        if(!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        int regieId = await _mediator.Send(createRegieCommand);
        return CreatedAtAction(nameof(GetById), new { id = regieId }, null);
    }
}
