using Microsoft.AspNetCore.Mvc;
using Regies.Application.Regies;

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
}
