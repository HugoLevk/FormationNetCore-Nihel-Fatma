using MediatR;
using Microsoft.AspNetCore.Mvc;
using Regies.Application.User.Commands.UpdateUserDetails;

namespace Regies.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class IdentityController(IMediator mediator) : ControllerBase
{

    [HttpPatch("user-details")]
    public async Task<IActionResult> UpdateUserDetails([FromBody] UpdateUserDetailsCommand command)
    {
        if(!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        await mediator.Send(command);
        return NoContent();
    }
}
