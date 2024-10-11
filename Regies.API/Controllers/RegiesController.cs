using Microsoft.AspNetCore.Mvc;
using Regies.Application.Regies;
using Regies.Application.Regies.DTOs;

namespace Regies.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RegiesController(IRegieService service) :  ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllRegies()
    {
        var regies = await service.GetAllRegies();
        return Ok(regies);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute]int id)
    {
        var regie = await service.GetRegieById(id);
        if (regie == null)
        {
            return NotFound();
        }
        return Ok(regie);
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateRegie([FromBody] CreateRegieDTO createRegieDTO)
    {
        var regieId = await service.CreateRegie(createRegieDTO);
        return CreatedAtAction(nameof(GetById), new { id = regieId }, null);
    }
}
