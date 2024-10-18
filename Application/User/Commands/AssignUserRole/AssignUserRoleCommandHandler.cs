using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Regies.Domain.Exceptions;

namespace Regies.Application.User.Commands.AssignUserRole;

public class AssignUserRoleCommandHandler(ILogger<AssignUserRoleCommandHandler> logger,
    UserManager<Domain.Model.User> userManager,
    RoleManager<IdentityRole> roleManager) : IRequestHandler<AssignUserRoleCommand>
{
    public async Task Handle(AssignUserRoleCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Assigning role {Role} to user {UserId}", request.Role, request.UserEmail);
        var user = await userManager.FindByEmailAsync(request.UserEmail) ?? throw new NotFoundException(nameof(Domain.Model.User), request.UserEmail);

        _= await roleManager.FindByNameAsync(request.Role) ?? throw new NotFoundException(nameof(IdentityRole), request.Role);

        await userManager.AddToRoleAsync(user, request.Role);
    }
}
