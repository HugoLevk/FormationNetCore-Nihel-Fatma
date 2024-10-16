﻿using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Regies.Application.User.Commands.AssignUserRole;
using Regies.Domain.Exceptions;

namespace Regies.Application.User.Commands.UnassignUserRole;

/// <summary>
/// Command handler for unassigning a user role.
/// </summary>
public class UnassignUserRoleCommandHandler(ILogger<UnassignUserRoleCommandHandler> logger,
        UserManager<Domain.Model.User> userManager,
        RoleManager<IdentityRole> roleManager,
        IUserContext userContext) : IRequestHandler<UnassignUserRoleCommand>
{ 

    /// <summary>
    /// Handles the unassign user role command.
    /// </summary>
    /// <param name="request">The unassign user role command.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public async Task Handle(UnassignUserRoleCommand request, CancellationToken cancellationToken)
    {
        CurrentUser currUser = await userContext.GetCurrentUser() ?? throw new UnauthorizedAccessException("No Current user is logged in.");
        logger.LogInformation("Unassigning role {Role} from user {UserId} requested by [{CurrentUser}]", request.Role, request.UserEmail, currUser);

        var user = await userManager.FindByEmailAsync(request.UserEmail) ?? throw new NotFoundException(nameof(Domain.Model.User), request.UserEmail);

        _ = await roleManager.FindByNameAsync(request.Role) ?? throw new NotFoundException(nameof(IdentityRole), request.Role);

        await userManager.RemoveFromRoleAsync(user, request.Role);
    }
}
