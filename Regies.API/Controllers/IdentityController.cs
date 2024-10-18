using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Regies.Application.User.Commands.AssignUserRole;
using Regies.Application.User.Commands.UnassignUserRole;
using Regies.Application.User.Commands.UpdateUserDetails;
using Regies.Domain.Constants;

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

    [HttpPost("assignRole")]
    [Authorize(Roles = "Admin")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> AssignUserRole(AssignUserRoleCommand command)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        await mediator.Send(command);
        return NoContent();
    }

    [HttpDelete("unassignRole")]
    [Authorize(Roles = "Admin")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UnassignUserRole(UnassignUserRoleCommand command)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        await mediator.Send(command);
        return NoContent();
    }

}
